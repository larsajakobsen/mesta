using Mesta.Users.Api.Gateways.Keycloak.Auth;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Refit;

namespace Mesta.Users.Api.Gateways.Keycloak;

public static class KeycloakRegistration
{
    public static IServiceCollection AddKeycloak(this IServiceCollection services, IConfiguration configuration)
    {
        // Add Keycloak config to the container
        services.AddOptions<KeycloakAccessTokenConfiguration>().BindConfiguration("Gateways:Keycloak:AccessTokenConfig");

        // Add the Http client
        services.AddHttpClient<IKeycloakAccessTokenProvider, KeycloakAccessTokenProvider>();

        // Add token handler
        services.TryAddScoped<KeycloakAccessTokenHandler>();
        services
            .AddRefitClient<IKeycloakApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration["Gateways:Keycloak:AdminUrl"]!))
            .AddHttpMessageHandler<KeycloakAccessTokenHandler>();

        services.AddScoped<KeycloakFacade>();


        return services;
    }
}