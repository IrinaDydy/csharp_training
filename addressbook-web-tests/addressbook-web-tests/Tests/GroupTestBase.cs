using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class GroupTestBase:AuthTestBase
    {
        [TearDown]
        public void CompareGroupsDB_UI()
        {
            if (GroupsCompareDB_UINedded)
            {
                List<GroupData> groupsFromUI = app.Groups.GetGroupList();
                List<GroupData> groupsFromDB = GroupData.GetAll();
                groupsFromDB.Sort();
                groupsFromUI.Sort();
                Assert.AreEqual(groupsFromDB,groupsFromUI);

            }
        }

    }
}
