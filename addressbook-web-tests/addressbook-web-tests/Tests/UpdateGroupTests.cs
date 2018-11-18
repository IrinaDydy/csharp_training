using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class UpdateGroupTests: AuthTestBase
    {
        [Test]
        public void UpdateGroupTest()
        {
            GroupData group = new GroupData("TestGroup");
            group.Header = "Test group header";
            group.Footer = "Test group footer";
            app.Groups.Update(1,group);

        }
    }
}
