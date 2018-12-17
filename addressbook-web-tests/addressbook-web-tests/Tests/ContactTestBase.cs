using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactTestBase:AuthTestBase
    {
        [TearDown]
        public void CompareContactDB_UI()
        {
            if (GroupsCompareDB_UINedded)
            {
                List<ContactData> FromUI = app.Contacts.GetContactList();
                List<ContactData> FromDB = ContactData.GetAll();
                FromDB.Sort();
                FromUI.Sort();
                Assert.AreEqual(FromDB, FromUI);

            }
        }
    }
}
