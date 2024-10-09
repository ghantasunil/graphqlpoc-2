using HotChocolate.Fusion.SourceSchema.Types;
using HotChocolate.Pagination;

using Microsoft.EntityFrameworkCore;

using Reviews.Data;

namespace Users.Types;

public static partial class ReviewOperations
{
    [Lookup]
    [Query]
    [UseProjection]
    public static async Task<Review?> GetReviewAsync(
        int id,
        ReviewDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.Reviews
            .AsNoTracking()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    [Query]
    [UsePaging]
    [UseProjection]
    [UseSorting]
    public static IQueryable<Review> GetReviews(
        ReviewDbContext dbContext)
    {
        return dbContext.Reviews
            .OrderBy(review => review.Id)
            .AsNoTracking();
    }

    [Lookup]
    public static async Task<IReadOnlyCollection<Review>?> GetReviewsByUserIdAsync(
        [Is("user { id }")] int id,
        ReviewDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.Reviews
            .AsNoTracking()
            .Where(r => r.UserId == id)
            .OrderBy(r => r.Id)
            .ToListAsync(cancellationToken);
    }

    //[Lookup]
    //public static async Task<Page<Review>?> GetReviewsByUserIdAsync(
    //    [Is("user { id }")] int id,
    //    ISelection selection,
    //    ReviewByUserIdDataLoader reviewByUserId,
    //    CancellationToken cancellationToken)
    //    => await reviewByUserId
    //        .Select(selection)
    //        .LoadAsync(id, cancellationToken);
}

public sealed class ReviewDataLoader
{
    [DataLoader]
    public static async Task<Dictionary<int, Page<Review>>> GetReviewByUserIdAsync(
        IReadOnlyList<int> keys,
        PagingArguments pagingArguments,
        ReviewDbContext context,
        CancellationToken ct)
        => await context.Reviews
            .AsNoTracking()
            .Where(p => keys.Contains(p.UserId))
            .OrderBy(p => p.Id)
            .ToBatchPageAsync(t => t.UserId, pagingArguments, ct);
}
