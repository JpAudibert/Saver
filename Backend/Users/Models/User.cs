using Backend.Transactions.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Users.Models;

public class User
{
    [BsonId]
    public ObjectId Id { get; set; } = default!;
    public string? RegularId { get; set; } = default!;
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string IdentificationNumber { get; set; }
    public string Password { get; set; } = default!;
    public bool IsActive { get; set; }
    public List<Transaction> Transactions { get; set; } = [];
}
