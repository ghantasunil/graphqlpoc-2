using System.ComponentModel.DataAnnotations.Schema;

namespace Reviews.Data;

public sealed class Review
{
    [Column("id")]
    public int Id { get; set; }
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("product_id")]
    public int ProductId { get; set; }
    [Column("rating")]
    public required int Rating { get; set; }
    [Column("review")]
    public required string Comment { get; set; }
    [Column("created_at")]
    public required string CreatedAt { get; set; }
}
