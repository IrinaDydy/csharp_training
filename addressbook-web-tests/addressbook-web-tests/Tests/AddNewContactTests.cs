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
            var oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
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
            var currentContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            currentContacts.Sort();
            Assert.AreEqual(oldContacts, currentContacts);
        }


    }
}
