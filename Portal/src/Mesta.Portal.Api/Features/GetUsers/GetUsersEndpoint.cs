namespace Mesta.Users.Api.Features.GetUsers;

public static class GetUsersEndpoint
{
    public static async Task<IResult> Execute(GetUsersFeature getUsers)
    {
        var response = await getUsers.Execute();

        return string.IsNullOrWhiteSpace(response.ErrorMessage)
            ? Results.Ok(response)
            : Results.Problem(detail: response.ErrorMessage, statusCode: (int)response.StatusCode);
    }
}