using Mesta.Users.Api.Gateways.Keycloak.Models;
using Refit;

namespace Mesta.Users.Api.Gateways.Keycloak;

[Headers("Authorization: Bearer")]
public interface IKeycloakApi
{
    [Post("/users")]
    Task<HttpResponseMessage> RegisterUser(KeycloakUser user);

    [Get("/users")]
    Task<IList<GetUserResponse>> GetUsers();

    [Get("/users/{keyCloakUserId}")]
    Task<GetUserResponse?> GetUser(Guid keyCloakUserId);

    [Put("/users/{keyCloakUserId}")]
    Task<HttpResponseMessage> UpdateUser(Guid keyCloakUserId, GetUserResponse user);

    [Put("/users/{keyCloakUserId}/execute-actions-email")]
    Task ExecuteUserAction(string keyCloakUserId, string[] actions);

    [Delete("/users/{keyCloakUserId}")]
    Task<HttpResponseMessage> DeleteUser(Guid keyCloakUserId);

    [Put("/users/{keyCloakUserId}")]
    Task<HttpResponseMessage> UpdateUser(Guid keyCloakUserId, KeycloakUser user);

    [Put("")]
    Task UpdateRealm([Body] KeycloakRealm realmJson);

    [Get("")]
    Task<KeycloakRealm> GetRealm();

    [Get("/roles")]
    Task<KeycloakRole[]> GetRealmRoles();

    [Get("/roles/{roleName}")]
    Task<KeycloakRole> GetRealmRoles(string roleName);

    [Delete("/users/{keyCloakUserId}/role-mappings/realm")]
    Task<HttpResponseMessage> RemoveRealmRole(Guid keyCloakUserId, [Body] KeycloakRole[] roles);

    [Post("/users/{keyCloakUserId}/role-mappings/realm")]
    Task<HttpResponseMessage> AddRealmRole(Guid keyCloakUserId, [Body] KeycloakRole[] roles);

}