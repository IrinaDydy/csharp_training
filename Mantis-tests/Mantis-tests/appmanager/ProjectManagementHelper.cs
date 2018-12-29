using OpenQA.Selenium;
using System.Collections.Generic;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {

        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {

        }


        public ProjectManagementHelper Create(ProjectData project)
        {
            manager.Navigation.GoToManageProjectsPage();
            InitProjectCreation();
            FillGroupForm(project);
            SubmitProjectCreation();

            return this;
        }

        public ProjectManagementHelper Remove(ProjectData toBeRemoved)
        {
            manager.Navigation.GoToManageProjectsPage();
            SelectProject(toBeRemoved);
            RemoveProject();

            return this;
        }

        public ProjectManagementHelper SelectProject(ProjectData toBeRemoved)
        {
            By locator = By.LinkText(toBeRemoved.Name);
            driver.FindElement(locator).Click();

            return this;
        }

        public ProjectManagementHelper RemoveProject()
        {
            driver.FindElement(By.XPath(".//*[@value='Delete Project']")).Click();
            driver.FindElement(By.XPath(".//*[@value='Delete Project']")).Click();
            return this;
        }

        public ProjectManagementHelper FillGroupForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            driver.FindElement(By.Id("project-description")).SendKeys(project.Description);
            return this;
        }

        public ProjectManagementHelper InitProjectCreation()
        {
            driver.FindElement(By.XPath("//button[contains(.,'Create New Project')]")).Click();
            return this;
        }

        public ProjectManagementHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath(".//*[@value='Add Project']")).Click();
            return this;
        }

        public List<ProjectData> GetProjectsList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigation.GoToManageProjectsPage();

            ICollection<IWebElement> elements = driver.FindElements(By.XPath(".//div[2]/table/tbody/tr"));

            foreach (IWebElement element in elements)
            {
                string name = element.FindElement(By.XPath(".//td[1]/a")).Text;
                string description = element.FindElement(By.XPath(".//td[5]")).Text;

                projects.Add(new ProjectData(name, description));
            }
            return projects;
        }

    }
}
