using Mesta.Users.Api.Domain.Extensions;

namespace Mesta.Users.Api.Domain.ValueObjects;

public record LastName(string Value) : ValueObject<string>(Value);