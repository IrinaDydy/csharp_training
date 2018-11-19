using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class RemoveGroupTests: AuthTestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            app.Groups.CreateEmptyGroupIfNeeded().Remove(1);

        }
    }
}
