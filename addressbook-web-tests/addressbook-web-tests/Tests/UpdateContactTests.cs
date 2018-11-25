using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class UpdateContactTests: AuthTestBase
    {
        [Test]
        public void UpdateContactTest()
        {
            ContactData contact = new ContactData("Иван", "Иванов");
            contact.Email = "ivanov.ivan@gmail.com";
            var oldContacts = app.Contacts.GetContactList();
            if (oldContacts.Count == 0) oldContacts.Add(new ContactData("", ""));
            ContactData oldContact = oldContacts[0];
            app.Contacts.CreateEmptyContactIfNeeded().Update(0,contact);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            var currentContacts = app.Contacts.GetContactList();
            oldContacts[0].Lastname = contact.Lastname;
            oldContacts[0].Firstname = contact.Firstname;
            oldContacts.Sort();
            currentContacts.Sort();
            Assert.AreEqual(oldContacts, currentContacts);


            foreach (var currentcontact in currentContacts)
            {
                if (currentcontact.Id == oldContact.Id)
                {
                    Assert.AreEqual(contact.Firstname, currentcontact.Firstname);
                    Assert.AreEqual(contact.Lastname, currentcontact.Lastname);
                }
            }

        }

    }
}
