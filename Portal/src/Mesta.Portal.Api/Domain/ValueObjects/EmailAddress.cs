using System.Net.Mail;
using Mesta.Users.Api.Domain.Extensions;

namespace Mesta.Users.Api.Domain.ValueObjects;

public record EmailAddress : ValueObject<string>
{
    public EmailAddress(string Value) : base(Value)
    {
        if (!IsValidEmail(Value))
            throw new ArgumentException($"{Value} is not a valid email address");
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            _ = new MailAddress(email);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}