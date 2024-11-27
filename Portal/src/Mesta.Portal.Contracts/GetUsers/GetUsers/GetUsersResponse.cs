using Mesta.Users.Api.Contracts.GetUsers;
using System.Net;

namespace Mesta.Users.Api.Contracts.GetUsers.GetUsers;

public record GetUsersResponse(IList<UserListItem> Users, string? ErrorMessage = null, HttpStatusCode StatusCode = HttpStatusCode.OK);
