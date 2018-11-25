using System.Security;
using NUnit.Framework;

namespace addressbook_web_tests
{
    /// <summary>
    /// Summary description for CreateNewGroupTests
    /// </summary>
    [TestFixture]
    public class CreateNewGroupTests : AuthTestBase
    {

        [Test]
        public void CreateNewGroupTest()
        {
            GroupData group = new GroupData("Test123");
            group.Header = "Test group header";
            group.Footer = "Test group footer";
            var oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());
            var currentGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            currentGroups.Sort();
            Assert.AreEqual(oldGroups, currentGroups);

        }

        [Test]
        public void CreateNewGroupTestWithBadName()
        {
            GroupData group = new GroupData("a'a");
            var oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            var currentGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            currentGroups.Sort();
            Assert.AreEqual(oldGroups, currentGroups);

        }

        [Test]
        public void CreateEmptyGroupTest()
        {
            GroupData group = new GroupData("");
            var oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            var currentGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            currentGroups.Sort();
            Assert.AreEqual(oldGroups, currentGroups);

        }

    }


}
