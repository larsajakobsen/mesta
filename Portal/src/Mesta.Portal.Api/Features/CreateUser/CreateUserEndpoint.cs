using FluentValidation;
using Mesta.Users.Api.Contracts.CreateUser;

namespace Mesta.Users.Api.Features.CreateUser;

public static class CreateUserEndpoint
{
    public static async Task<IResult> Execute(
        CreateUserRequest command,
        IValidator<CreateUserRequest> validator,
        CreateUserFeature createUser)
    {
        var validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
            return Results.ValidationProblem(validationResult.ToDictionary());

        var response = await createUser.Execute(command);

        return response.ErrorMessage == null
            ? Results.Ok(response)
            : Results.Problem(response.ErrorMessage, statusCode: (int)response.StatusCode);
    }
}