using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class RemoveGroupTests:TestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            SelectGroup(1);
            RemoveGroup();
            ReturnToGroupsPage();
            Logout();
        }
    }
}
