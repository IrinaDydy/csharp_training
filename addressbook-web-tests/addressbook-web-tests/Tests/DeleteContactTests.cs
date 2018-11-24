using System.Linq;
using System.Runtime.Serialization.Formatters;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class DeleteContactTests: AuthTestBase
    {

        [Test]
        public void DeleteContactTest()
        {
            var oldContacts = app.Contacts.GetContactList();
            if (oldContacts.Count == 0) oldContacts.Add(new ContactData("",""));
            app.Contacts.CreateEmptyContactIfNeeded().RemoveOneContact(0);
            var currentContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            currentContacts.Sort();
            Assert.AreEqual(oldContacts, currentContacts);
        }

    }
}
