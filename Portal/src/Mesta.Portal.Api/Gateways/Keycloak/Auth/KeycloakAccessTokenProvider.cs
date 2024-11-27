using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Mesta.Users.Api.Gateways.Keycloak.Auth;

public interface IKeycloakAccessTokenProvider
{
    Task<string> GetToken();
}

public class KeycloakAccessTokenProvider(
    ILogger<KeycloakAccessTokenProvider> logger,
    HttpClient httpClient,
    IOptions<KeycloakAccessTokenConfiguration> options,
    IMemoryCache memoryCache)
    : IKeycloakAccessTokenProvider
{
    private readonly KeycloakAccessTokenConfiguration _accessTokenConfig = options.Value;
    private const string TokenCacheKey = "Keycloak.AccessToken";

    private static readonly SemaphoreSlim Lock = new(1, 1);

    public async Task<string> GetToken()
    {
        await Lock.WaitAsync();

        try
        {
            return (await memoryCache.GetOrCreateAsync(TokenCacheKey, GetFromProvider))!;
        }
        finally
        {
            Lock.Release();
        }
    }

    private async Task<string> GetFromProvider(ICacheEntry cacheEntry)
    {
        var username = _accessTokenConfig.Username;

        logger.LogInformation("Getting access token for Keycloak with user {username}", username);

        var request = new HttpRequestMessage(HttpMethod.Post, _accessTokenConfig.Url)
        {
            Content = new FormUrlEncodedContent(new KeyValuePair<string?, string?>[]
            {
                new("username", _accessTokenConfig.Username),
                new("password", _accessTokenConfig.Password),
                new("client_id", _accessTokenConfig.ClientId),
                new("grant_type", _accessTokenConfig.GrantType)
            })
        };

        using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();

        await using var responseContentStream = await response.Content.ReadAsStreamAsync();

        var tokenResponse = await JsonSerializer.DeserializeAsync<KeycloakAccessTokenResponse>(responseContentStream, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        // ReSharper disable once PossibleLossOfFraction
        cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(tokenResponse!.ExpiresIn / 2);

        return tokenResponse.AccessToken;
    }
}