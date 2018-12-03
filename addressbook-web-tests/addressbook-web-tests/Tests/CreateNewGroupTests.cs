using System.Collections;
using System.Collections.Generic;
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

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for (var i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }

            return groups;
        }


        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void CreateNewGroupTest(GroupData group)
        {
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

    }


}
