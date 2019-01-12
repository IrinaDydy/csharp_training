using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalAPITest : TestBase
    {
        [Test]
        public void RemoveProject()
        {
            List<ProjectData> oldProjects = app.API.GetProjectsList();

            if (oldProjects.Count == 0)
            {

                app.API.CreateProject(new ProjectData(RandomString(), RandomString()));
                oldProjects = app.API.GetProjectsList();

            }

            ProjectData toBeRemoved = oldProjects[0];
            oldProjects.RemoveAt(0);

            app.API.RemoveProject(toBeRemoved);

            List<ProjectData> newProjects = app.API.GetProjectsList();

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
