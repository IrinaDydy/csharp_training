using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTest : TestBase
    {
        [Test]
        public void CreateProject()
        {
            List<ProjectData> oldProjects = app.Project.GetProjectsList();

            ProjectData addProject = new ProjectData(RandomString(), RandomString());

            oldProjects.Add(addProject);

            app.Project.Create(addProject);

            List<ProjectData> newProjects = app.Project.GetProjectsList();

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);

        }
    }
}
