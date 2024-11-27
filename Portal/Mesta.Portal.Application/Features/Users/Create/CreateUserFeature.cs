using Mesta.Users.Api.Contracts;
using Mesta.Users.Api.Contracts.CreateUser;
using Refit;

namespace Mesta.Portal.Application.Features.Users.Create;

public class CreateUserFeature
{
    private readonly IUserApi userApi;

    public CreateUserFeature(IUserApi userApi)
    {
        this.userApi = userApi;
    }

    /// <summary>
    /// Create new user
    /// </summary>
    /// <param name="username"></param>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="email"></param>
    /// <returns>Creation results (including errors per field)</returns>
    public async Task<CreateUserResponse> Execute(string username, string firstName, string lastName, string email)
    {
        try
        {
            await userApi.CreateUser(new CreateUserRequest(username!, firstName!, lastName!, email!));

            return new CreateUserResponse(true);
        }
        catch (ValidationApiException e)
        {
            if (e.Content == null || e.Content.Errors.Count == 0)
                return new CreateUserResponse(true);

            return new CreateUserResponse(false, e.Content.Errors);
        }
    }

}
