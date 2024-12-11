using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesta.ProjectManagement.Integrations.Mdc.Projects
{

    public class ProjectDto
    {
        public int ProjectNumber { get; set; }
        public string? Description { get; set; }
        public string? ProjectType { get; set; }
        public string? Status { get; set; }
        public Guid MainProject { get; set; }
        public Guid Id { get; set; }
        public string ETag { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
    }

}
