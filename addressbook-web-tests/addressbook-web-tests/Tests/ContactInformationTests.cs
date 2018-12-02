using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class ContactInformationTests:AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            app.Contacts.CreateEmptyContactIfNeeded();
            ContactData FromTable = app.Contacts.GetContactDataFromTable(0);
            ContactData FromForm = app.Contacts.GetContactDataFromForm(0);

            Assert.AreEqual(FromTable,FromForm);
            Assert.AreEqual(FromForm.Address,FromTable.Address);
            Assert.AreEqual(FromForm.AllEmails, FromTable.AllEmails);
            Assert.AreEqual(FromForm.AllPhones, FromTable.AllPhones);
        }

        [Test]
        public void DetailsContactInformationTest()
        {
            app.Contacts.CreateEmptyContactIfNeeded();
            string FromDetailInfo = app.Contacts.GetContactDataFromDetailInfo(0);
            ContactData FromForm = app.Contacts.GetContactDataFromForm(0);
            Assert.AreEqual(FromForm.AllDetails, FromDetailInfo);

        }

    }
}
