using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
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
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
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
            
            SelectContact(index);
            RemoveContact();
            AcceptNextAllert(true, "^Delete 1 addresses[\\s\\S]$");
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper RemoveOneContact(ContactData contact)
        {

            SelectContact(contact.Id);
            RemoveContact();
            AcceptNextAllert(true, "^Delete 1 addresses[\\s\\S]$");
            Thread.Sleep(2000);
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper Update(int index, ContactData contact)
        {
            InitEditContact(index);
            FillContactForm(contact);
            UpdateContact();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper Update(ContactData oldcontact, ContactData contact)
        {
            InitEditContact(oldcontact.Id);
            FillContactForm(contact);
            UpdateContact();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper InitEditContact(int index)
        {
            //driver.FindElement(By.XPath("(//img[@alt='Edit'])["+ (index+1) + "]")).Click();
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[7].FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper InitEditContact(string id)
        {
            //driver.FindElement(By.XPath("(//img[@alt='Edit'])["+ (index+1) + "]")).Click();
            driver.FindElement(By.XPath("//a[contains(@href, 'edit.php?id=" + id+"')]")).Click();//By.XPath("//a[contains(text(), 'long')]"
            return this;
        }

        public ContactHelper DetailInfoContact(int index)
        {
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6].FindElement(By.TagName("a")).Click();
            return this;
        }


        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+(index+2)+"]/td[1]/input")).Click();
            return this;
        }

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.Id(id)).Click();
            return this;
        }

        public ContactHelper CreateEmptyContactIfNeeded()
        {
            if (!IsElementPresent(By.Name("entry")))//By.XPath("//*[@id=\"maintable\"]/tbody/tr[2]")))
            {
                Create(new ContactData("",""));
            }
            //Assert.IsTrue(IsElementPresent(By.XPath("//*[@id=\"maintable\"]/tbody/tr[2]")));
            return this;
        }

        public ContactHelper AcceptNextAllert(bool acceptNextAlert, string allertMessage)//"^Delete 1 addresses[\\s\\S]$"
        {
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(acceptNextAlert), allertMessage));
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
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
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            driver.FindElement(
                By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[3]")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            driver.FindElement(
                By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[36]")).Click();

            Type(By.Name("byear"), contact.Byear);

            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            driver.FindElement(
                By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[3]"))
                .Click();
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            driver.FindElement(
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
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                var elements = driver.FindElements(By.Name("entry"));
                foreach (var element in elements)
                {
                    contactCache.Add(new ContactData(element.FindElement(By.XPath(".//td[3]")).Text,
                        element.FindElement(By.XPath(".//td[2]")).Text) {Id = element.FindElement(By.TagName("input")).GetAttribute("Id") });
                }
                
            }
            return contactCache;
        }
        public int GetContactCount()
        {
            return ContactData.GetAll().Count; //driver.FindElements(By.Name("entry")).Count;
        }


        public ContactData GetContactDataFromForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitEditContact(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string bday = driver.FindElement(By.Name("bday")).FindElement(By.XPath("./option[@selected]")).Text;
            string bmonth = driver.FindElement(By.Name("bmonth")).FindElement(By.XPath("./option[@selected]")).Text;
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aday = driver.FindElement(By.Name("aday")).FindElement(By.XPath("./option[@selected]")).Text;
            string amonth = driver.FindElement(By.Name("amonth")).FindElement(By.XPath("./option[@selected]")).Text;
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");


            return new ContactData(firstName, lastName)
            {
                Address = address,
                Hometelephone = homePhone,
                Mobiletelephone = mobilePhone,
                Worktelephone = workPhone,
                Email =  email,
                Email2 = email2,
                Email3 = email3,
                Middlename = middlename,
                Nickname = nickname,
                Title = title,
                Company = company,
                Fax = fax,
                Homepage = homepage,
                Bday = bday,
                Bmonth = bmonth,
                Byear = byear,
                Aday = aday,
                Amonth = amonth,
                Ayear = ayear,
                Address2 = address2,
                Phone2 = phone2,
                Notes = notes
            };

        }

        public ContactData GetContactDataFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string emails = cells[4].Text;
            string phones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = phones,
                AllEmails = emails

            };

        }


        public string GetContactDataFromDetailInfo(int index)
        {
            manager.Navigator.OpenHomePage();
            DetailInfoContact(index);
            //IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            return driver.FindElement(By.Id("content")).Text.Replace("\r\n\r\n", "\r\n");

        }


    }
}
