using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_tests.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();


        }

        public bool GroupsCompareDB_UINedded = true;

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            
            int l = Convert.ToInt32(rnd.NextDouble()*max);
            StringBuilder builder = new StringBuilder();
            for (var i = 1; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble()*65)));
            }
            return builder.ToString();
        }

    }
}
