using System.Collections.Generic;


namespace mantis_tests
{
    public class APIHelper : HelperBase
    {


        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }



        public List<ProjectData> GetProjectsList()
        {
            List<ProjectData> projectData = new List<ProjectData>();

            Mantis_tests.Mantis.MantisConnectPortTypeClient client = new Mantis_tests.Mantis.MantisConnectPortTypeClient();

            Mantis_tests.Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible("administrator", "root");

            foreach (var item in projects)
            {
                projectData.Add(new ProjectData(item.name, item.description, item.id));
            }

            return projectData;
        }

        public void CreateProject(ProjectData project1)
        {
            Mantis_tests.Mantis.MantisConnectPortTypeClient client = new Mantis_tests.Mantis.MantisConnectPortTypeClient();
            Mantis_tests.Mantis.ProjectData project = new Mantis_tests.Mantis.ProjectData();
            project.name = project1.Name;
            project.description = project1.Description;
            client.mc_project_add("administrator", "root", project);
        }



        public void RemoveProject(ProjectData project1)
        {
            Mantis_tests.Mantis.MantisConnectPortTypeClient client = new Mantis_tests.Mantis.MantisConnectPortTypeClient();
            client.mc_project_delete("administrator", "root", project1.Id);
        }
    }
}

