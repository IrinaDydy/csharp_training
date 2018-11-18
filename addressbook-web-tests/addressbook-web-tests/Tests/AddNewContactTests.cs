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
            app.Contacts.Create(contact);
        }

        [Test]
        public void AddEmptyContactTest()
        {
            ContactData contact = new ContactData("", "");

            app.Contacts.Create(contact);
        }


    }
}
