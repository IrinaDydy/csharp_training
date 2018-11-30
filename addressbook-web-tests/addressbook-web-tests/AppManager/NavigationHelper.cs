using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class NavigationHelper:HelperBase
    {
        private string baseUrl;

        public NavigationHelper(ApplicationManager manager, string baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseUrl)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseUrl);
        }

        public void GoToHomePage()
        {
            if ((driver.Url == baseUrl))
            {
                return;
            }
            driver.FindElement(By.LinkText("home page")).Click();
        }

        public void ReturnToGroupsPage()
        {
            if ((driver.Url==baseUrl+"/group.php")&& IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void GoToGroupsPage()
        {
            if ((driver.Url == baseUrl + "/group.php") && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
