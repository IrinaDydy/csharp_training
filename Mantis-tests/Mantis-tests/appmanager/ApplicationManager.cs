
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using OpenQA.Selenium.Firefox;


namespace mantis_tests
{
    public class ApplicationManager
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private NavigationHelper navigation;
        private LoginHelper login;
        private ProjectManagementHelper project;

        private string baseURL;

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();

            navigation = new NavigationHelper(this, baseURL);
            login = new LoginHelper(this);
            project = new ProjectManagementHelper(this);
            API = new APIHelper(this);
        }


        public IWebDriver Driver => driver;


        public NavigationHelper Navigation => navigation; 
        public LoginHelper Login => login; 
        public ProjectManagementHelper Project => project;
        public APIHelper API { get; private set; }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

    }
}
