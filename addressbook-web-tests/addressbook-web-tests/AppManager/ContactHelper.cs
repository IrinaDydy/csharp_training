using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }


        public ContactHelper RemoveOneContact(int index)
        {
            CreateEmptyContactIfNeeded();
            SelectContact(index);
            RemoveContact();
            AcceptNextAllert(true, "^Delete 1 addresses[\\s\\S]$");
            return this;
        }

        public ContactHelper Update(int index, ContactData contact)
        {
            CreateEmptyContactIfNeeded();
            InitEditContact(index);
            FillContactForm(contact);
            UpdateContact();
            return this;
        }

        public ContactHelper InitEditContact(int index)
        {
            manager.Driver.FindElement(By.XPath("(//img[@alt='Edit'])["+ index + "]")).Click();

            return this;
        }

        public ContactHelper UpdateContact()
        {
            manager.Driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            manager.Driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+index+"]/td/input")).Click();
            return this;
        }

        public ContactHelper CreateEmptyContactIfNeeded()
        {
            if (!IsElementPresent(By.XPath("//*[@id=\"maintable\"]/tbody/tr[2]")))
            {
                Create(new ContactData("",""));
            }
            return this;
        }

        public ContactHelper AcceptNextAllert(bool acceptNextAlert, string allertMessage)//"^Delete 1 addresses[\\s\\S]$"
        {
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(acceptNextAlert), allertMessage));
            return this;
        }
        public ContactHelper RemoveContact()
        {
            manager.Driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }


        public ContactHelper FillContactForm(ContactData contact)
        {
            
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Hometelephone);
            Type(By.Name("mobile"), contact.Mobiletelephone);
            Type(By.Name("work"), contact.Worktelephone);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            manager.Driver.FindElement(By.Name("bday")).Click();
            new SelectElement(manager.Driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            manager.Driver.FindElement(
                By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[3]")).Click();
            manager.Driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(manager.Driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            manager.Driver.FindElement(
                By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[36]")).Click();

            Type(By.Name("byear"), contact.Byear);

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

            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            manager.Driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

    }
}
