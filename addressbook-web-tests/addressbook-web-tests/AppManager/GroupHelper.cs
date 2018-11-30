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
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
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
            driver.FindElement(By.Name("new")).Click();
            return this;
        }


        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper EditGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
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
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }


        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                var elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (var element in elements)
                {
                    GroupData group = new GroupData(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    };
                    groupCache.Add(group);
                }

                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (var i = 0; i < groupCache.Count; i++)
                {
                    groupCache[i].Name = i < shift ? "" : parts[i-shift].Trim();
                }

            }
            return new List<GroupData>(groupCache);
        }


        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
