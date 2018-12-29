using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {

        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void GoToHomepage()
        {
            driver.Navigate().GoToUrl(baseURL + "mantisbt-2.18.0/login_page.php");
        }

        public void GoToManageProjectsPage()
        {
            if (driver.Url == baseURL + "/mantisbt-2.18.0/manage_proj_page.php")
            {
                return;
            }

            driver.FindElement(By.XPath(".//*[@class='menu-icon fa fa-gears']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.LinkText("Manage Projects"))).Click();

        }
    }
}
