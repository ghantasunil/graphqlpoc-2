using System.ComponentModel.DataAnnotations.Schema;

namespace Users.Data;

public sealed class User
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public required string Name { get; set; }
    [Column("email")]
    public required string Email { get; set; }
    [Column("password")]
    public required string Password { get; set; }
}