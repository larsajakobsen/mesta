using Mesta.ProjectManagement.Features.Projects;

namespace Mesta.ProjectManagement.Features.Projects.Fetch
{
    public class FetchProjectsResponse(List<Project> projects)
    {
        public readonly List<Project> Projects = projects;
    }
}