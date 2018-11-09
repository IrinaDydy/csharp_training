using NUnit.Framework;

namespace addressbook_web_tests
{
    /// <summary>
    /// Summary description for CreateNewGroupTests
    /// </summary>
    [TestFixture]
    public class CreateNewGroupTests : TestBase
    {

        [Test]
        public void CreateNewGroupTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("TestGroup");
            group.Header = "Test group header";
            group.Footer = "Test group footer";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            Logout();
        }

    }


}
