using System.Net;
using Mesta.Users.Api.Contracts.CreateUser;
using Mesta.Users.Api.Database;
using Mesta.Users.Api.Domain;
using Mesta.Users.Api.Domain.ValueObjects;
using Mesta.Users.Api.Gateways.Keycloak;
using Microsoft.EntityFrameworkCore;

namespace Mesta.Users.Api.Features.CreateUser;

public class CreateUserFeature(AppDbContext db, KeycloakFacade keyCloak, ILogger<CreateUserFeature> logger)
{
    public async Task<CreateUserResponse> Execute(CreateUserRequest command)
    {
        logger.LogInformation("Creating user {user}", command.Username);

        try
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Username == command.Username.Trim());

            if (user != null)
                return new(false, Guid.Empty, "User exists", HttpStatusCode.BadRequest);

            var firstName = new FirstName(command.FirstName);
            var lastName = new LastName(command.LastName);
            var emailAddress = new EmailAddress(command.Email);
            var username = new Username(command.Username);

            var keycloakResponse = await keyCloak.RegisterUser(username, firstName, lastName, emailAddress);

            if (!keycloakResponse.IsSuccess || keycloakResponse.RegisteredUserId == null)
            {
                logger.LogError("Could not create user {username} in Keycloak: {error}", command.Username, keycloakResponse.ErrorMessage);
                return new(Success: false, ErrorMessage: "Could not create user", StatusCode: HttpStatusCode.InternalServerError);
            }

            user = User.Create(keycloakResponse.RegisteredUserId, username, firstName, lastName, emailAddress);
            await db.Users.AddAsync(user);

            var result = await db.SaveChangesAsync();
            if (result == 0)
            {
                logger.LogCritical("Could not save changes on user creation");
                return new(Success: false, ErrorMessage: "Could not save changes", StatusCode: HttpStatusCode.InternalServerError);
            }

            logger.LogInformation("User {user} created", command.Username);

            return new(Success: true, UserId: user.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Could not create user {user}", command.Username);
            return new(Success: false, ErrorMessage: "Could not create user", StatusCode: HttpStatusCode.InternalServerError);
        }
    }
}