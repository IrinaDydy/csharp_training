using OpenQA.Selenium;

namespace addressbook_web_tests
{

    public class HelperBase
    {
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
        }


        protected bool IsElementPresent(By by)
        {
            try
            {
                manager.Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool IsAlertPresent()
        {
            try
            {
                manager.Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        protected string CloseAlertAndGetItsText(bool acceptNextAlert=true)
        {
            try
            {
                IAlert alert = manager.Driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                manager.Driver.FindElement(locator).Clear();
                manager.Driver.FindElement(locator).SendKeys(text);
            }
        }

    }
}
