namespace Mesta.CompetenceManagement.Integrations.Mdc.Persons;

public class NationalIdentificationNumberDto
{
    public string IdNumber { get; set; }
    public string IdNumberType { get; set; }
}

public class EmploymentDto
{
    public int EmployeeNumber { get; set; }
    public string UserName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Position { get; set; }
    public int PositionPercentage { get; set; }
    public Guid Project { get; set; }
    public Guid Organization { get; set; }
    public Guid Manager { get; set; }
    public string WorkMobilePhone { get; set; }
    public string WorkEmail { get; set; }
}

public class PersonDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<NationalIdentificationNumberDto> NationalIdentificationNumbers { get; set; }
    public string PersonalMobilePhone { get; set; }
    public string PersonalEmail { get; set; }
    public EmploymentDto Employment { get; set; }
    public Guid Id { get; set; }
    public string ETag { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
}
