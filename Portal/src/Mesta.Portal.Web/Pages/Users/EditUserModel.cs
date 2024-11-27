namespace Mesta.Portal.Web.Pages.Users;

public class EditUserModel(Guid userId, string firstName, string lastName, string email)
{
    public Guid UserId { get; set; } = userId;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string Email { get; set; } = email;
}