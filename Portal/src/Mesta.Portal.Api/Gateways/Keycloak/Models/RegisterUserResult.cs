using Mesta.Users.Api.Domain.ValueObjects;

namespace Mesta.Users.Api.Gateways.Keycloak.Models;

public record RegisterUserResult(bool IsSuccess, UserId? RegisteredUserId, string? ErrorMessage);