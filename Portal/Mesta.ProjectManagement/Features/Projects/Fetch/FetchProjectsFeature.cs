using Mesta.ProjectManagement.Domain.Interfaces;
using Mesta.ProjectManagement.Features.Projects;

namespace Mesta.ProjectManagement.Features.Projects.Fetch
{
    public class FetchProjectsFeature
    {
        private readonly IProjectClient _projectClient;

        public FetchProjectsFeature(IProjectClient projectClient)
        {
            _projectClient = projectClient;
        }

        public async Task<FetchProjectsResponse> Execute()
        {
            var p = await _projectClient.GetProjects();

            var projects = new List<Project>();

            projects.Add(
                new Project()
                {
                    Id = 1,
                    Name = "Midtoddveien 3",
                    Responsible = "Ivar Andersen",
                    Address = "Midtoddveien 3, 0494 Oslo",
                    Status = "Avsluttet"
                });

            projects.Add(
                new Project()
                {
                    Id = 2,
                    Name = "Tåsen tunellen",
                    Responsible = "Jon Hansen",
                    Address = "Tåsen alle 32, 0394 Oslo",
                    Status = "Ikke påbegynt"
                });

            projects.Add(
                new Project()
                {
                    Id = 3,
                    Name = "BaneNOR Strekning 473",
                    Responsible = "Anders Johansen",
                    Address = "54.2231,42.2312",
                    Status = "Pågående"
                });

        https://mtp-mdcproject-dev-wa.azurewebsites.net/swagger/index.html#/Projects/post_Projects

            return new FetchProjectsResponse(projects);
        }
    }
}
