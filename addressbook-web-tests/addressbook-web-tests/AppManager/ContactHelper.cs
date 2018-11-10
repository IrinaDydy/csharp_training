using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper:HelperBase
    {
        public ContactHelper(ApplicationManager manager):base(manager)
        { }
        public ContactHelper SubmitContactCreation()
        {
            manager.Driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactCreationForm(contact);
            SubmitContactCreation();
            manager.Navigator.GoToHomePage();
            manager.Auth.Logout();
            return this;
        }
        public ContactHelper FillContactCreationForm(ContactData contact)
        {
            manager.Driver.FindElement(By.Name("firstname")).Click();
            manager.Driver.FindElement(By.Name("firstname")).Click();
            manager.Driver.FindElement(By.Name("firstname")).Clear();
            manager.Driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            manager.Driver.FindElement(By.Name("middlename")).Click();
            manager.Driver.FindElement(By.Name("middlename")).Clear();
            manager.Driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            manager.Driver.FindElement(By.Name("lastname")).Click();
            manager.Driver.FindElement(By.Name("lastname")).Clear();
            manager.Driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            manager.Driver.FindElement(By.Name("nickname")).Click();
            manager.Driver.FindElement(By.Name("nickname")).Clear();
            manager.Driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            manager.Driver.FindElement(By.Name("title")).Click();
            manager.Driver.FindElement(By.Name("title")).Clear();
            manager.Driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            manager.Driver.FindElement(By.Name("company")).Click();
            manager.Driver.FindElement(By.Name("company")).Clear();
            manager.Driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            manager.Driver.FindElement(By.Name("address")).Click();
            manager.Driver.FindElement(By.Name("address")).Clear();
            manager.Driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            manager.Driver.FindElement(By.Name("home")).Click();
            manager.Driver.FindElement(By.Name("home")).Clear();
            manager.Driver.FindElement(By.Name("home")).SendKeys(contact.Hometelephone);
            manager.Driver.FindElement(By.Name("mobile")).Click();
            manager.Driver.FindElement(By.Name("mobile")).Clear();
            manager.Driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobiletelephone);
            manager.Driver.FindElement(By.Name("work")).Click();
            manager.Driver.FindElement(By.Name("work")).Clear();
            manager.Driver.FindElement(By.Name("work")).SendKeys(contact.Worktelephone);
            manager.Driver.FindElement(By.Name("fax")).Click();
            manager.Driver.FindElement(By.Name("fax")).Clear();
            manager.Driver.FindElement(By.Name("fax")).SendKeys(contact.Fax);
            manager.Driver.FindElement(By.Name("email")).Click();
            manager.Driver.FindElement(By.Name("email")).Clear();
            manager.Driver.FindElement(By.Name("email")).SendKeys(contact.Email);
            manager.Driver.FindElement(By.Name("email2")).Click();
            manager.Driver.FindElement(By.Name("email2")).Clear();
            manager.Driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            manager.Driver.FindElement(By.Name("email3")).Click();
            manager.Driver.FindElement(By.Name("email3")).Clear();
            manager.Driver.FindElement(By.Name("email3")).SendKeys(contact.Email3);
            manager.Driver.FindElement(By.Name("homepage")).Click();
            manager.Driver.FindElement(By.Name("homepage")).Clear();
            manager.Driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage);
            manager.Driver.FindElement(By.Name("bday")).Click();
            new SelectElement(manager.Driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            manager.Driver.FindElement(
                By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[3]")).Click();
            manager.Driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(manager.Driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            manager.Driver.FindElement(
                By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[36]")).Click();
            manager.Driver.FindElement(By.Name("byear")).Click();
            manager.Driver.FindElement(By.Name("byear")).Clear();
            manager.Driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            manager.Driver.FindElement(By.Name("aday")).Click();
            new SelectElement(manager.Driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            manager.Driver.FindElement(
                By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[3]"))
                .Click();
            manager.Driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(manager.Driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            manager.Driver.FindElement(
                By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[36]"))
                .Click();
            manager.Driver.FindElement(By.Name("ayear")).Click();
            manager.Driver.FindElement(By.Name("ayear")).Clear();
            manager.Driver.FindElement(By.Name("ayear")).SendKeys(contact.Ayear);
            manager.Driver.FindElement(By.Name("address2")).Click();
            manager.Driver.FindElement(By.Name("address2")).Clear();
            manager.Driver.FindElement(By.Name("address2")).SendKeys(contact.Address2);
            manager.Driver.FindElement(By.Name("phone2")).Click();
            manager.Driver.FindElement(By.Name("phone2")).Clear();
            manager.Driver.FindElement(By.Name("phone2")).SendKeys(contact.Phone2);
            manager.Driver.FindElement(By.Name("notes")).Click();
            manager.Driver.FindElement(By.Name("notes")).Clear();
            manager.Driver.FindElement(By.Name("notes")).SendKeys(contact.Notes);
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            manager.Driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

    }
}
