namespace Mesta.Users.Api.Contracts.UpdateUser;

public record UpdateUserRequest(
    Guid UserId,
    string FirstName,
    string LastName,
    string Email);