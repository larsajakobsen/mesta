namespace Mesta.Users.Api.Contracts.GetUsers;

public record UserListItem(Guid Id, string Username, string FirstName, string LastName, string Email);