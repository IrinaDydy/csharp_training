using NUnit.Framework;
namespace addressbook_web_tests
{
    /// <summary>
    /// Summary description for AddNewContactTests
    /// </summary>
    [TestFixture]
    public class AddNewContactTests: AuthTestBase
    {

        [Test]
        public void AddNewContactTest()
        {
            ContactData contact = new ContactData("Иван", "Иванов");
            contact.Email = "ivanov.ivan@gmail.com";
            contact.Email2 = "ivanov2.ivan@gmail.com";
            contact.Hometelephone = "123456789";
            contact.Mobiletelephone = "987654321";
            var oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            var currentContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            currentContacts.Sort();
            Assert.AreEqual(oldContacts, currentContacts);
        }

        [Test]
        public void AddEmptyContactTest()
        {
            ContactData contact = new ContactData("", "");

            var oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            var currentContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            currentContacts.Sort();
            Assert.AreEqual(oldContacts, currentContacts);
        }


    }
}
