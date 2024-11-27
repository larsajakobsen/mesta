using System.Net;

namespace Mesta.Users.Api.Contracts.UpdateUser;

public record UpdateUserResponse(bool Success, Guid? UserId = null, string? ErrorMessage = null, HttpStatusCode StatusCode = HttpStatusCode.OK);