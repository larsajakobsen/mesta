using System.Net;

namespace Mesta.Users.Api.Contracts.CreateUser;

public record CreateUserResponse(bool Success, Guid? UserId = null, string? ErrorMessage = null, HttpStatusCode StatusCode = HttpStatusCode.OK);