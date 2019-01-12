using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationAPITest : TestBase
    {
        [Test]
        public void CreateProject()
        {
            List<ProjectData> oldProjects = app.API.GetProjectsList();

            ProjectData addProject = new ProjectData(RandomString(), RandomString());

            oldProjects.Add(addProject);

            app.API.CreateProject(addProject);

            List<ProjectData> newProjects = app.API.GetProjectsList();

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);


        }
    }
}
