using Mesta.Users.Api.Database;
using Mesta.Users.Api.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Mesta.Users.Api.Database.Tables.User;

public static class UserQueries
{
    public static async Task<Domain.User?> GetUser(this AppDbContext db, UserId userId)
        => await db.Users.SingleOrDefaultAsync(u => u.Id == userId);
}