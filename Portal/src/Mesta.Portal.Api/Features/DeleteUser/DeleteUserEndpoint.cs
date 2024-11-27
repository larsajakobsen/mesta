using Mesta.Users.Api.Extensions;

namespace Mesta.Users.Api.Features.DeleteUser;

public static class DeleteUserEndpoint
{
    public static async Task<IResult> Execute(
        DeleteUserFeature deleteUser,
        Guid userId)
    {
        if (userId.IsEmpty("User", out var result))
            return result;

        var response = await deleteUser.Execute(new(userId));

        return response.ErrorMessage == null
            ? Results.Ok(response)
            : Results.Problem(response.ErrorMessage, statusCode: (int)response.StatusCode);
    }
}