using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class DeleteContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteContactFromGroupTest()
        {

            GroupData group;
            int i = 0;
            do
            {
                group = GroupData.GetAll()[i];
                i++;

            } while (group.GetContacts().Count < 1);

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList.First();

            app.Contacts.DeleteContactToGroup(contact, group);


            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }


    }
}
