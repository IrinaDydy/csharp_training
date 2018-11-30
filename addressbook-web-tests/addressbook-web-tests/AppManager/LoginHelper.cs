﻿using OpenQA.Selenium;

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
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }


        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() && GetLoggetUserName() ==account.Username;

        }

        public string GetLoggetUserName()
        {
            string UserName = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return UserName.Substring(1, UserName.Length - 2);
        }

    }
}
