using Reviews.Data;

namespace Users.Types;

[ObjectType<Review>]
public static partial class ReviewExtensions
{
    public static User GetUser([Parent] Review review)
    {
        return new User(review.UserId);
    }
}

public class User
{
    public User(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}