using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTest : TestBase
    {
        [Test]
        public void RemoveProject()
        {
            List<ProjectData> oldProjects = app.Project.GetProjectsList();

            if (oldProjects.Count == 0)
            {
                app.Project.Create(new ProjectData(RandomString(), RandomString()));
                oldProjects = app.Project.GetProjectsList();

            }

            ProjectData toBeRemoved = oldProjects[0];
            oldProjects.RemoveAt(0);

            app.Project.Remove(toBeRemoved);

            List<ProjectData> newProjects = app.Project.GetProjectsList();

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
