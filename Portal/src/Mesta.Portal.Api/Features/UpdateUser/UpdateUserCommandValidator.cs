using FluentValidation;
using Mesta.Users.Api.Contracts.UpdateUser;

namespace Mesta.Users.Api.Features.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}