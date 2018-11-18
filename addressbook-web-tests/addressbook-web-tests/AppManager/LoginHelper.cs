using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class LoginHelper:HelperBase
    {
        public LoginHelper(ApplicationManager manager):base(manager)
        { }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            manager.Driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }


        public void Logout()
        {
            if (IsLoggedIn())
            {
                manager.Driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsElementPresent(By.Name("logout")) &&
                   manager.Driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text ==
                   "(" + account.Username + ")";

        }

    }
}
