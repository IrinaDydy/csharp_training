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
            if (manager.Driver.Url == baseUrl)
            {
                return;
            }
            manager.Driver.Navigate().GoToUrl(baseUrl);
        }

        public void GoToHomePage()
        {
            if ((manager.Driver.Url == baseUrl))
            {
                return;
            }
            manager.Driver.FindElement(By.LinkText("home page")).Click();
        }

        public void ReturnToGroupsPage()
        {
            if ((manager.Driver.Url==baseUrl+"/group.php")&& IsElementPresent(By.Name("new")))
            {
                return;
            }
            manager.Driver.FindElement(By.LinkText("group page")).Click();
        }

        public void GoToGroupsPage()
        {
            if ((manager.Driver.Url == baseUrl + "/group.php") && IsElementPresent(By.Name("new")))
            {
                return;
            }
            manager.Driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
