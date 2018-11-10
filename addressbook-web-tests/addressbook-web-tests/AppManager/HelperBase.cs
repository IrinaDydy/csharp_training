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
    }
}
