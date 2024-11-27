using Mesta.ProjectManagement.Features.Projects;

namespace Mesta.ProjectManagement.Features.Projects.Get
{
    public class GetProjectResponse(Project project)
    {
        public readonly Project Project = project;
    }
}