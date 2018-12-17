using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using Newtonsoft.Json;
using NUnit.Framework;

namespace addressbook_web_tests
{
    /// <summary>
    /// Summary description for CreateNewGroupTests
    /// </summary>
    [TestFixture]
    public class CreateNewGroupTests : GroupTestBase
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


        public static IEnumerable<GroupData> GetGroupDataFromJson()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText("Data\\groups.json"));
        }

        [Test, TestCaseSource("GetGroupDataFromJson")]
        public void CreateNewGroupTest(GroupData group)
        {
            var oldGroups = GroupData.GetAll();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());
            var currentGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            currentGroups.Sort();
            Assert.AreEqual(oldGroups, currentGroups);

        }

        [Test]
        public void CreateNewGroupTestWithBadName()
        {
            GroupData group = new GroupData("a'a");
            var oldGroups = GroupData.GetAll();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            var currentGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            currentGroups.Sort();
            Assert.AreEqual(oldGroups, currentGroups);

        }

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUI = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            Console.WriteLine("From UI: "+end.Subtract(start));

            start = DateTime.Now;

            List<GroupData> fromDB = GroupData.GetAll();
            end = DateTime.Now;
            Console.WriteLine("From DB: "+ end.Subtract(start));
        }

    }


}
