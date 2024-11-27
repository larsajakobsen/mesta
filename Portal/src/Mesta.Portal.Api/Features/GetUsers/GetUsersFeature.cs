using System.Net;
using Mesta.Users.Api.Contracts.GetUsers;
using Mesta.Users.Api.Contracts.GetUsers.GetUsers;
using Mesta.Users.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace Mesta.Users.Api.Features.GetUsers;

public class GetUsersFeature(AppDbContext db, ILogger<GetUsersFeature> logger)
{
    public async Task<GetUsersResponse> Execute()
    {
        try
        {
            var users = await db.Users
                .Select(x => new UserListItem(x.Id, x.Username!, x.FirstName!, x.LastName!, x.Email!))
                .ToListAsync();

            return new(Users: users);
        }
        catch (Exception ex)
        {
            var errorMessage = "Could not get users";
            logger.LogError(ex, errorMessage);
            return new(Users: new List<UserListItem>(), ErrorMessage: errorMessage, StatusCode: HttpStatusCode.InternalServerError);
        }
    }
}