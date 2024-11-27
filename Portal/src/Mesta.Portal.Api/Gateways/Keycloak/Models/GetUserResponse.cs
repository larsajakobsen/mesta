#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Mesta.Users.Api.Gateways.Keycloak.Models;


public class GetUserResponse
{
    public Guid id { get; set; }
    public long createdTimestamp { get; set; }
    public string username { get; set; }
    public bool enabled { get; set; }
    public bool totp { get; set; }
    public bool emailVerified { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public object[] disableableCredentialTypes { get; set; }
    public object[] requiredActions { get; set; }
    public Dictionary<string, string[]>? attributes { get; set; }
    public int notBefore { get; set; }
    public Access access { get; set; }
}

public class Access
{
    public bool manageGroupMembership { get; set; }
    public bool view { get; set; }
    public bool mapRoles { get; set; }
    public bool impersonate { get; set; }
    public bool manage { get; set; }
}
public class UserAttributes
{
    public List<string> role { get; set; }
    public List<string> orgs { get; set; }
}


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.