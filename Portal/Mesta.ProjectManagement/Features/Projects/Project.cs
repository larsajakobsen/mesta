namespace Mesta.ProjectManagement.Features.Projects
{
    public class Project
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Responsible { get; init; } = string.Empty;
        public string Address { get; init; } = string.Empty;
        public string Status { get; init; } = string.Empty;
    }
}