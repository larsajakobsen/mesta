using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesta.CompetenceManagement.Integrations.Landax
{
    public class LandaxCompetenceResponse
    {
        public string dataModel { get; set; }
        public LandaxCompetence[] value { get; set; }
        public string nextLink { get; set; }
    }

    public class LandaxCompetence
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Description { get; set; }
        public object Email { get; set; }
        public object Phone { get; set; }
        public object ProcessId { get; set; }
        public int? EquipmentId { get; set; }
        public int? ResponsibleCoworkerId { get; set; }
        public object SupplierId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Place { get; set; }
        public string Position { get; set; }
        public bool IncludeInCV { get; set; }
        public bool SendEmailOnExpiring { get; set; }
        public int? Rating { get; set; }
        public string Notes { get; set; }
        public object RenewalCompetencyId { get; set; }
        public bool IsActive { get; set; }
        public bool AllowExpire { get; set; }
        public bool IsPlanned { get; set; }
        public bool IsValid { get; set; }
        public bool IsExpired { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDemanded { get; set; }
        public int CountDocuments { get; set; }
        public int? TypeId { get; set; }
        public int? CoworkerId { get; set; }
        public object CustomerId { get; set; }
        public object ContactId { get; set; }
        public object ContactPersonId { get; set; }
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }
        public string Tag4 { get; set; }
        public string Tag5 { get; set; }
        public object ExternalId { get; set; }
        public DateTime? ChangedDateTime { get; set; }
        public object[] TagTypeIds { get; set; }
    }

}
