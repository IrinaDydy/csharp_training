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
            manager.Driver.Navigate().GoToUrl(baseUrl);
        }

        public void GoToHomePage()
        {
            manager.Driver.FindElement(By.LinkText("home page")).Click();
        }

        public void ReturnToGroupsPage()
        {
            manager.Driver.FindElement(By.LinkText("group page")).Click();
        }

        public void GoToGroupsPage()
        {
            manager.Driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
