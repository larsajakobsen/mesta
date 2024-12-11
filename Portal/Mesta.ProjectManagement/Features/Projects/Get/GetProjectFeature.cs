using Mesta.ProjectManagement.Domain;
using Mesta.ProjectManagement.Domain.Interfaces;
using Mesta.ProjectManagement.Features.Projects;

namespace Mesta.ProjectManagement.Features.Projects.Get
{
    public class GetProjectFeature
    {
        private readonly IProjectClient _projectClient;

        public GetProjectFeature(IProjectClient projectClient)
        {
            _projectClient = projectClient;
        }

        public async Task<Project> Execute(Guid projectId)
        {
            return await _projectClient.GetProject(projectId);
        }
    }
}
