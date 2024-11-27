using Mesta.Users.Api.Domain.ValueObjects;

namespace Mesta.Users.Api.Domain;

public class User
{
    public UserId Id { get; init; } = null!;
    public Username Username { get; private set; } = null!;
    public FirstName FirstName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public EmailAddress Email { get; private set; } = null!;
    public DateTime CreatedUtc { get; init; }

    public User()
    {
    }

    private User(
        UserId userId,
        Username username,
        FirstName firstName,
        LastName lastName,
        EmailAddress emailAddress)
    {
        Id = userId;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        Email = emailAddress;
        CreatedUtc = DateTime.UtcNow;
    }

    public static User Create(UserId userId, Username username, FirstName firstName, LastName lastName, EmailAddress emailAddress) =>
        new(userId, username, firstName, lastName, emailAddress);

    public void Update(FirstName firstName, LastName lastName, EmailAddress emailAddress)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = emailAddress;
    }
}