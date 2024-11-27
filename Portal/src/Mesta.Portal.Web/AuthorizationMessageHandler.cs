using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;

namespace Mesta.Portal.Web;

/// <summary>
/// Ensures that the Authorization header is forwarded to the API.
/// </summary>
public class AuthorizationMessageHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _contextAccessor;

    public AuthorizationMessageHandler(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancelToken)
    {
        if (_contextAccessor.HttpContext is null)
            throw new InvalidOperationException("HttpContext is null");

        var accessToken = await _contextAccessor.HttpContext.GetTokenAsync("access_token");
        if (!string.IsNullOrWhiteSpace(accessToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        return await base.SendAsync(request, cancelToken);
    }
}