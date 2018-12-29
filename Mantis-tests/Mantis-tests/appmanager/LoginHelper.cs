
using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {


        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            manager.Navigation.GoToHomepage();

            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys(account.Username);
            driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
    }
}

