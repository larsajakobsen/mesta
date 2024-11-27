using Mesta.Users.Api.Domain.Extensions;

namespace Mesta.Users.Api.Domain.ValueObjects;

public record UserId(Guid Value) : ValueObject<Guid>(Value);