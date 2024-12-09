using Mesta.ProjectManagement.Domain;

namespace Mesta.ProjectManagement.Domain.Interfaces
{
    public interface IProjectClient
    {
        Task<Project> GetProject(int id);
        Task<List<Project>> GetProjects();
    }
}
