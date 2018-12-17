using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class UpdateGroupTests: GroupTestBase
    {
        [Test]
        public void UpdateGroupTest()
        {
            GroupData group = new GroupData("TestGroup");
            group.Header = "Test group header";
            group.Footer = "Test group footer";
            var oldGroups = GroupData.GetAll();
            if (oldGroups.Count == 0) oldGroups.Add(new GroupData(""));
            GroupData oldGroup = oldGroups[0];
            app.Groups.CreateEmptyGroupIfNeeded().Update(oldGroup, group);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            var currentGroups = GroupData.GetAll();
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
