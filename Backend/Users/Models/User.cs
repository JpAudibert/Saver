using Backend.Spendings.Models;
using MongoDB.Bson;

namespace Backend.Users.Models;

public class User
{
    public ObjectId Id { get; set; } = default!;
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string IdentificationNumber { get; set; }
    public string Password { get; set; } = default!;
    public bool IsActive { get; set; }
    public List<Spending> Spendings { get; set; } = [];
}
