using Mesta.Users.Api.Contracts.CreateUser;
using Mesta.Users.Api.Contracts.DeleteUser;
using Mesta.Users.Api.Contracts.GetUsers.GetUsers;
using Mesta.Users.Api.Contracts.UpdateUser;
using Mesta.Users.Api.Features.CreateUser;
using Mesta.Users.Api.Features.DeleteUser;
using Mesta.Users.Api.Features.GetUsers;
using Mesta.Users.Api.Features.UpdateUser;

namespace Mesta.Users.Api.Features;

public static class EndpointConfiguration
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapPost("/user", CreateUserEndpoint.Execute).Produces<CreateUserResponse>();
        app.MapPut("/user", UpdateUserEndpoint.Execute).Produces<UpdateUserResponse>().RequireAuthorization();
        app.MapDelete("/user", DeleteUserEndpoint.Execute).Produces<DeleteUserResponse>().RequireAuthorization();
        app.MapGet("/users", GetUsersEndpoint.Execute).Produces<GetUsersResponse>().RequireAuthorization();
    }
}