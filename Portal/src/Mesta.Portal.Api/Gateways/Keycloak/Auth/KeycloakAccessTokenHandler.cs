namespace Mesta.Users.Api.Gateways.Keycloak.Auth;

public class KeycloakAccessTokenHandler(IKeycloakAccessTokenProvider accessTokenClient) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var auth = request.Headers.Authorization;

        if (auth is not null)
        {
            var token = await accessTokenClient.GetToken();
            request.Headers.Authorization = new(auth.Scheme, token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
