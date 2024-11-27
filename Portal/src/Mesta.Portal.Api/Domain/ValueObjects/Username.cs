using Mesta.Users.Api.Domain.Extensions;

namespace Mesta.Users.Api.Domain.ValueObjects;

public record Username(string Value) : ValueObject<string>(Value);