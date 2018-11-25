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
            var oldGroups = app.Groups.GetGroupList();
            if (oldGroups.Count == 0) oldGroups.Add(new GroupData(""));
            GroupData oldGroup = oldGroups[0];
            app.Groups.CreateEmptyGroupIfNeeded().Update(0,group);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            var currentGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = group.Name;
            oldGroups.Sort();
            currentGroups.Sort();
            Assert.AreEqual(oldGroups, currentGroups);

            foreach (var currentgroup in currentGroups)
            {
                if (currentgroup.Id == oldGroup.Id)
                {
                    Assert.AreEqual(group.Name, currentgroup.Name);
                }
            }
        }
    }
}
