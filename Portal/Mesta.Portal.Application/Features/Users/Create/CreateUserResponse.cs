namespace Mesta.Portal.Application.Features.Users.Create;

public class CreateUserResponse(bool Success, Dictionary<string, string[]>? Errors = null)
{
    public bool Success { get; } = Success;
    public Dictionary<string, string[]>? Errors { get; set; } = Errors;
}
