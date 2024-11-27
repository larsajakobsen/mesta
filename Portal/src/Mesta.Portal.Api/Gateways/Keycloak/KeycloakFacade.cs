using System.Net;
using System.Text.Json;
using Mesta.Users.Api.Domain.ValueObjects;
using Mesta.Users.Api.Gateways.Keycloak.Models;
using Refit;
using UserId = Mesta.Users.Api.Domain.ValueObjects.UserId;

namespace Mesta.Users.Api.Gateways.Keycloak;

public class KeycloakFacade(IKeycloakApi keycloakApi, ILogger<KeycloakFacade> logger)
{
    public async Task<RegisterUserResult> RegisterUser(Username username, FirstName firstName, LastName lastName, EmailAddress emailAddress)
    {
        try
        {
            logger.LogInformation("Registering user in Keycloak {@User}", new { username, firstName, lastName, emailAddress });

            var keycloakUser = CreateKeycloakUser(username, firstName, lastName, emailAddress);

            var response = await keycloakApi.RegisterUser(keycloakUser);
            if (!response.IsSuccessStatusCode)
                return new(false, null, response.ReasonPhrase);

            // Hack to get user id
            var userIdString = response.Headers.Location?.Segments.LastOrDefault();
            if (!Guid.TryParse(userIdString, out var userIdGuid))
                return new(false, null, "Could not get user id");

            var userId = new UserId(userIdGuid);

            // Send email to user, asking the user to update password
            await keycloakApi.ExecuteUserAction(userIdString, ["UPDATE_PASSWORD"]);

            return new(true, userId, null);
        }
        catch (Exception ex)
        {
            logger.LogError("Could not register user in Keycloak. User: {username}, Error: {message}", username.Value, ex.Message);
            return new(false, null, null);
        }
    }

    public async Task<bool> UpdateUser(Guid userId, FirstName firstName, LastName lastName, EmailAddress emailAddress)
    {
        var keycloakUser = await keycloakApi.GetUser(userId);

        if (keycloakUser == null)
        {
            return true;
        }

        keycloakUser.firstName = firstName.Value;
        keycloakUser.lastName = lastName.Value;
        keycloakUser.email = emailAddress.Value;

        await keycloakApi.UpdateUser(userId, keycloakUser);

        return true;
    }

    public async Task UpdateUserPassword(Guid userId) => await keycloakApi.ExecuteUserAction(userId.ToString(), ["UPDATE_PASSWORD"]);

    public async Task<DeleteUserResult> DeleteUser(Guid userId)
    {
        logger.LogInformation("Deleting User {userId} in Keycloak", userId);

        try
        {
            var keycloakUser = await keycloakApi.GetUser(userId);

            if (keycloakUser is null)
            {
                logger.LogWarning("Could not find User {userId} in Keycloak.", userId);
            }
            else
            {
                var response = await keycloakApi.DeleteUser(keycloakUser.id);
                if (response.IsSuccessStatusCode)
                {
                    return new(true);
                }

                logger.LogError("Could not delete User {userId} in Keycloak.", userId);
                return new(false);
            }

            return new(true);
        }
        catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            logger.LogError(ex, "Could not find User {userId} in Keycloak.", userId);
            return new(true);
        }
    }

    private static KeycloakUser CreateKeycloakUser(Username username, FirstName firstName, LastName lastName, EmailAddress emailAddress)
    {
        return new(
            Username: username!,
            FirstName: firstName!,
            LastName: lastName!,
            Email: emailAddress!,
            Enabled: true,
            Attributes: new Dictionary<string, string>(),
            []);
    }

    private async Task AddCustomAttributes(Guid userId, string attribute, IEnumerable<string> attributeIds)
    {
        var (success, user, values) = await GetUserAndAttributeList(userId, attribute);
        if (!success || values.Count == 0)
        {
            return;
        }

        values.AddRange(attributeIds);

        if (user!.attributes != null)
        {
            user.attributes[attribute] = values.ToArray();
            var response = await keycloakApi.UpdateUser(userId, user);
            response.EnsureSuccessStatusCode();
        }
    }

    private async Task RemoveCustomAttribute(Guid userId, string attribute, string attributeId)
    {
        var (success, user, values) = await GetUserAndAttributeList(userId, attribute);
        if (!success)
        {
            return;
        }

        values.Remove(attributeId);
        if (user!.attributes != null)
        {
            user.attributes[attribute] = values.ToArray();
        }

        var response = await keycloakApi.UpdateUser(userId, user);

        response.EnsureSuccessStatusCode();
    }

    private async Task<(bool success, GetUserResponse? user, List<string> attributes)> GetUserAndAttributeList(Guid userid, string attribute)
    {
        var user = await keycloakApi.GetUser(userid);
        if (user == null)
        {
            logger.LogWarning("Could not find User {userId} in Keycloak.", userid);
            return (false, null, []);
        }

        var attributeList = AttributesList(user.attributes, attribute);
        if (attributeList != null)
        {
            return (true, user, attributeList);
        }

        logger.LogWarning("Could not find {key} in custom attribute on User {userId} in Keycloak.", attribute, userid);
        return (false, user, []);
    }

    private static string Serialize(List<Guid> values) => JsonSerializer.Serialize(values);

    private static List<string>? AttributesList(Dictionary<string, string[]>? userAttributes, string keyName)
    {
        if (userAttributes == null || !userAttributes.TryGetValue(keyName, out var attribute))
        {
            return null;
        }

        return attribute.ToList();
    }
}