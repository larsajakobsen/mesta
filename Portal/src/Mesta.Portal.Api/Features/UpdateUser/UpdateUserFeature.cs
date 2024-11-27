using System.Net;
using Mesta.Users.Api.Contracts.UpdateUser;
using Mesta.Users.Api.Database;
using Mesta.Users.Api.Database.Tables.User;
using Mesta.Users.Api.Domain.ValueObjects;
using Mesta.Users.Api.Gateways.Keycloak;

namespace Mesta.Users.Api.Features.UpdateUser;

public class UpdateUserFeature(AppDbContext db, KeycloakFacade keyCloak, ILogger<UpdateUserFeature> logger)
{
    public async Task<UpdateUserResponse> Execute(UpdateUserRequest command)
    {
        try
        {
            logger.LogInformation("Editing user {userId}", command.UserId);

            var userId = new UserId(command.UserId);

            var user = await db.GetUser(userId);

            if (user == null)
                return new(Success: false, UserId: null, ErrorMessage: "User does not exist", StatusCode: HttpStatusCode.BadRequest);

            var firstName = new FirstName(command.FirstName);
            var lastName = new LastName(command.LastName);
            var emailAddress = new EmailAddress(command.Email);

            await keyCloak.UpdateUser(command.UserId, firstName, lastName, emailAddress);

            user.Update(firstName, lastName, emailAddress);

            await db.SaveChangesAsync();

            logger.LogInformation("User {userId} updated", command.UserId);

            return new(Success: true, UserId: user.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Could not edit user {userId}", command.UserId);
            return new(Success: false, UserId: null, ErrorMessage: "Could not update user", StatusCode: HttpStatusCode.InternalServerError);
        }
    }
}