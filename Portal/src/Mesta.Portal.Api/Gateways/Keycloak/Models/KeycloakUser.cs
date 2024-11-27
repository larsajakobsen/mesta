namespace Mesta.Users.Api.Gateways.Keycloak.Models;

public record KeycloakUser(
    string Username,
    string FirstName,
    string LastName,
    string Email,
    bool Enabled,
    Dictionary<string, string> Attributes,
    string[] RequiredActions);
