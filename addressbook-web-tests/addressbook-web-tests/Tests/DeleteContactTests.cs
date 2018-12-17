using System.Linq;
using System.Runtime.Serialization.Formatters;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class DeleteContactTests: ContactTestBase
    {

        [Test]
        public void DeleteContactTest()
        {
            var oldContacts = ContactData.GetAll();
            if (oldContacts.Count == 0) oldContacts.Add(new ContactData("",""));
            ContactData toBeRemoved = oldContacts[0];
            app.Contacts.CreateEmptyContactIfNeeded().RemoveOneContact(toBeRemoved);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            var currentContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            currentContacts.Sort();
            Assert.AreEqual(oldContacts, currentContacts);

            foreach (ContactData contact in currentContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }

    }
}
