using Mesta.ProjectManagement.Features.Projects;

namespace Mesta.ProjectManagement.Features.Projects.Get
{
    public class GetProjectFeature
    {
        public GetProjectFeature() { }

        public async Task<GetProjectResponse> Execute(int projectId)
        {
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

            return new GetProjectResponse(projects.First(p => p.Id == projectId));
        }
    }
}
