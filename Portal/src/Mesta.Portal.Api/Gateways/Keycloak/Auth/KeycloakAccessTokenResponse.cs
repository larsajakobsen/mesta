using System.Text.Json.Serialization;

namespace Mesta.Users.Api.Gateways.Keycloak.Auth;

public class KeycloakAccessTokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = null!;

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = null!;

    [JsonPropertyName("refresh_expires_in")]
    public int RefreshExpiresIn { get; set; }
}
