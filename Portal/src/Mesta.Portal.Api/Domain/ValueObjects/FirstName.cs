using Mesta.Users.Api.Domain.Extensions;

namespace Mesta.Users.Api.Domain.ValueObjects;

public record FirstName(string Value) : ValueObject<string>(Value);