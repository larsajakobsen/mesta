namespace Mesta.ProjectManagement.Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public int ProjectNumber { get; set; }
        public string? Description { get; set; }
        public string? ProjectType { get; set; }
        public string? Status { get; set; }
        public Guid MainProject { get; set; }
    }
}
