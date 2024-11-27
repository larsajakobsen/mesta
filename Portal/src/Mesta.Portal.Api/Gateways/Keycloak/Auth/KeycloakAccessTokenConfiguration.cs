namespace Mesta.Users.Api.Gateways.Keycloak.Auth;

public class KeycloakAccessTokenConfiguration
{
    public string Url { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string GrantType { get; set; } = null!;
    public string ClientId { get; set; } = null!;
}
