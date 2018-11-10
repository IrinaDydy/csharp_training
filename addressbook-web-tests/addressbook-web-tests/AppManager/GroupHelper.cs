using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class GroupHelper:HelperBase
    {
        public GroupHelper(ApplicationManager manager):base(manager)
        { }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigator.ReturnToGroupsPage();
            manager.Auth.Logout();
            return this;
        }

        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            RemoveGroup();
            manager.Navigator.ReturnToGroupsPage();
            manager.Auth.Logout();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            manager.Driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            manager.Driver.FindElement(By.Name("group_name")).Click();
            manager.Driver.FindElement(By.Name("group_name")).Click();
            manager.Driver.FindElement(By.Name("group_name")).Clear();
            manager.Driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            manager.Driver.FindElement(By.Name("group_header")).Click();
            manager.Driver.FindElement(By.Name("group_header")).Clear();
            manager.Driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            manager.Driver.FindElement(By.Name("group_footer")).Click();
            manager.Driver.FindElement(By.Name("group_footer")).Clear();
            manager.Driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            manager.Driver.FindElement(By.Name("new")).Click();
            return this;
        }


        public GroupHelper SelectGroup(int index)
        {
            manager.Driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            manager.Driver.FindElement(By.Name("delete")).Click();
            return this;
        }
    }
}
