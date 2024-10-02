using Microsoft.EntityFrameworkCore;

using Reviews.Data;

namespace Users.Types;

public static partial class ReviewOperations
{
    [Query]
    public static async Task<Review?> GetReviewAsync(
        int id,
        ReviewDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.Reviews
            .AsNoTracking()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync<Review>();
    }

    [Query]
    [UsePaging]
    [UseProjection]
    public static IQueryable<Review> GetReviews(
        ReviewDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return dbContext.Reviews
            .AsNoTracking()
            .OrderBy(r => r.Id);
    }
}
