using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mesta.CompetenceManagement.Domain
{
    public class Competence
    {
        public Competence()
        {
            Status = string.Empty;
            Type = string.Empty;
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string? PersonName { get; set; }
        public int? TypeId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; } 
        public string? Place { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; } 
        public string? Notes { get; set; }  
        public string? Projects { get; set; }   
        public string? Program { get; set; }  
        public string? Issuer { get; set; }  
        public string? Responsible { get; set; }
        public bool IsActive { get; set; }
        public bool IsValid { get; set; }
        public bool SendEmailOnExpiring { get; set; }
        public bool IncludeInCV { get; set; }

    }
}
