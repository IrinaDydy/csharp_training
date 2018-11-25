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
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.CreateEmptyGroupIfNeeded().Remove(0);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            var currentGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            currentGroups.Sort();
            Assert.AreEqual(currentGroups, oldGroups);

            foreach (GroupData group in currentGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
