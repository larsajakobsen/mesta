using FluentValidation;
using Mesta.Users.Api.Contracts.UpdateUser;

namespace Mesta.Users.Api.Features.UpdateUser;

public static class UpdateUserEndpoint
{
    public static async Task<IResult> Execute(
        UpdateUserRequest command,
        IValidator<UpdateUserRequest> validator,
        UpdateUserFeature updateUser)
    {
        var validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
            return Results.ValidationProblem(validationResult.ToDictionary());

        var response = await updateUser.Execute(command);

        return response.ErrorMessage == null
            ? Results.Ok(response)
            : Results.Problem(response.ErrorMessage, statusCode: (int)response.StatusCode);
    }
}