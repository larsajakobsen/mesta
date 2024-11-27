namespace Mesta.Users.Api.Contracts.CreateUser;

public record CreateUserRequest(
    string Username,
    string FirstName,
    string LastName,
    string Email);