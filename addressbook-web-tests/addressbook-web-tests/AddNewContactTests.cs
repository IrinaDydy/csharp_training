using NUnit.Framework;
namespace addressbook_web_tests
{
    /// <summary>
    /// Summary description for AddNewContactTests
    /// </summary>
    [TestFixture]
    public class AddNewContactTests:TestBase
    {

        [Test]
        public void AddNewContactTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));

            InitContactCreation();
            ContactData contact = new ContactData("Иван", "Иванов");
            contact.Email = "ivanov.ivan@gmail.com";
            FillContactCreationForm(contact);
            SubmitContactCreation();
            GoToHomePage();
            Logout();

        }


    }
}
