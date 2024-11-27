using System.Net;

namespace Mesta.Users.Api.Contracts.DeleteUser;

public record DeleteUserResponse(bool Success, string? ErrorMessage = null, HttpStatusCode StatusCode = HttpStatusCode.OK);