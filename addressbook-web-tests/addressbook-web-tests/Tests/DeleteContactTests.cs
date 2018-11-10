using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class DeleteContactTests:TestBase
    {

        [Test]
        public void DeleteContactTest()
        {
            app.Contacts.RemoveOneContact(3);
        }

    }
}
