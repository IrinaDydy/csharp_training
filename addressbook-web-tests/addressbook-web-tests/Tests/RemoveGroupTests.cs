using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class RemoveGroupTests:TestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            app.Groups.Remove(1);

        }
    }
}
