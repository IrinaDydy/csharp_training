using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class DeleteContactTests: AuthTestBase
    {

        [Test]
        public void DeleteContactTest()
        {
            app.Contacts.RemoveOneContact(2);
        }

    }
}
