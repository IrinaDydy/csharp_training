using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class LoginHelper:HelperBase
    {
        public LoginHelper(ApplicationManager manager):base(manager)
        { }

        public void Login(AccountData account)
        {
            manager.Driver.FindElement(By.Name("user")).Clear();
            manager.Driver.FindElement(By.Name("user")).SendKeys(account.Username);
            manager.Driver.FindElement(By.Name("pass")).Click();
            manager.Driver.FindElement(By.Name("pass")).Clear();
            manager.Driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            manager.Driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }


        public void Logout()
        {
            manager.Driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
