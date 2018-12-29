
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{

    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();

            app.Login.Login(new AccountData("administrator", "root"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }

        public static string RandomString()
        {
            return Path.GetRandomFileName().Replace(".", "");
        }
    }
}
