using Mesta.Users.Api.Contracts.CreateUser;
using Mesta.Users.Api.Contracts.DeleteUser;
using Mesta.Users.Api.Contracts.GetUsers.GetUsers;
using Mesta.Users.Api.Contracts.UpdateUser;
using Refit;

namespace Mesta.Users.Api.Contracts;

[Headers("Authorization: Bearer")]
public interface IUserApi
{
    [Post("/user")]
    Task<CreateUserResponse> CreateUser(CreateUserRequest createUserCommand);

    [Put("/user")]
    Task<UpdateUserResponse> UpdateUser(UpdateUserRequest updateUserCommand);

    [Delete("/user")]
    Task<DeleteUserResponse> DeleteUser(Guid userId);

    [Get("/users")]
    Task<GetUsersResponse> GetUsers();
}