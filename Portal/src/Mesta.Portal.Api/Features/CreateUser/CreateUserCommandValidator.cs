using FluentValidation;
using Mesta.Users.Api.Contracts.CreateUser;

namespace Mesta.Users.Api.Features.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Username)
            .MinimumLength(3)
            .NotEmpty();
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}