using System.Collections.Generic;
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
            return this;
        }

        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            RemoveGroup();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Update(int index, GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            EditGroup();
            FillGroupForm(group);
            SubmitEditGroup();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            manager.Driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            manager.Driver.FindElement(By.Name("new")).Click();
            return this;
        }


        public GroupHelper SelectGroup(int index)
        {
            manager.Driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            manager.Driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper EditGroup()
        {
            manager.Driver.FindElement(By.Name("edit")).Click();
            return this;
        }


        public GroupHelper CreateEmptyGroupIfNeeded()
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsElementPresent(By.XPath("//*[@id=\"content\"]/form/span[1]")))
            {
                Create(new GroupData(""));
            }
            //Assert.IsTrue(IsElementPresent(By.XPath("//*[@id=\"content\"]/form/span[1]")));
            return this;
        }

        public GroupHelper SubmitEditGroup()
        {
            manager.Driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            var elements = manager.Driver.FindElements(By.CssSelector("span.group"));
            foreach (var element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }
    }
}
