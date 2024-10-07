using HotChocolate.Fusion.SourceSchema.Types;

using Microsoft.EntityFrameworkCore;

using Users.Data;

namespace Users.Types;
public static partial class UserOperations
{
    [Query]
    [Lookup]
    public static async Task<User?> GetUserAsync(
        int id,
        UserDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.Users
            .AsNoTracking()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }
}