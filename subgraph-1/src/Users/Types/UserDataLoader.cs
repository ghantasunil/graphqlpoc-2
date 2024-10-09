using GreenDonut.Projections;

using Microsoft.EntityFrameworkCore;

using Users.Data;
namespace Users.Types;

#pragma warning disable GD0001
public static class UserDataLoader
{
    [DataLoader]
    public static async Task<IReadOnlyDictionary<int, User>> GetUserByIdAsync(
        IReadOnlyList<int> keys,
        IDbContextFactory<UserDbContext> dbContextFactory,
        ISelectorBuilder selector,
        CancellationToken cancellationToken)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);

        return await dbContext.Users
            .AsNoTracking()
            .Where(v => keys.Contains(v.Id))
            // .Select(selector, key: v => v.Id)
            .ToDictionaryAsync(v => v.Id, cancellationToken);
    }
}
#pragma warning restore GD0001
