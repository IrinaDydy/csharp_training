using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class RemoveGroupTests: AuthTestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            var oldGroups = app.Groups.GetGroupList();
            if (oldGroups.Count == 0) oldGroups.Add(new GroupData(""));
            app.Groups.CreateEmptyGroupIfNeeded().Remove(0);
            var currentGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            currentGroups.Sort();
            Assert.AreEqual(currentGroups, oldGroups);
        }
    }
}
