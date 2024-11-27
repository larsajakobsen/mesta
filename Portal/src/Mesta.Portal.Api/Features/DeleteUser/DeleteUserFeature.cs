using System.Net;
using Mesta.Users.Api.Contracts.DeleteUser;
using Mesta.Users.Api.Database;
using Mesta.Users.Api.Database.Tables.User;
using Mesta.Users.Api.Domain.ValueObjects;
using Mesta.Users.Api.Gateways.Keycloak;

namespace Mesta.Users.Api.Features.DeleteUser;

public class DeleteUserFeature(AppDbContext db, KeycloakFacade keyCloak, ILogger<DeleteUserFeature> logger)
{
    public async Task<DeleteUserResponse> Execute(UserId userId)
    {
        logger.LogInformation("Deleting user {userId}", userId.Value);

        try
        {
            var user = await db.GetUser(userId);
            if (user == null)
            {
                logger.LogInformation("User {userId} do not exists", userId.Value);
                return new(Success: false);
            }

            var result = await keyCloak.DeleteUser(user.Id.Value);
            if (!result.IsSuccess)
            {
                logger.LogWarning("User {userid} missing i Keycloak on delete", userId);
            }

            db.Users.Remove(user);

            var records = await db.SaveChangesAsync();
            if (records == 0)
            {
                logger.LogCritical("Could not save changes on user deletion");
                return new(Success: false, ErrorMessage: "Could not save changes", StatusCode: HttpStatusCode.InternalServerError);
            }

            logger.LogInformation("Deleted user {userId}", userId);

            return new(Success: true);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Could not delete user {userId}", userId.Value);
            return new(Success: false, ErrorMessage: "Could not delete user", StatusCode: HttpStatusCode.InternalServerError);
        }
    }
}