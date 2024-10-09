using GreenDonut.Projections;

using HotChocolate.Execution.Processing;
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
        UserByIdDataLoader dataLoader,
        ISelection selection,
        CancellationToken cancellationToken)
    {
        return (await dataLoader
                .Select(selection)
                .LoadAsync(new List<int> { id }, cancellationToken))
                .FirstOrDefault();
    }

    [Query]
    [UsePaging]
    [UseProjection]
    [UseSorting]
    public static IQueryable<User> GetUsers(
        UserDbContext dbContext)
    {
        return dbContext.Users
            .OrderBy(u => u.Id)
            .AsNoTracking();
    }
}