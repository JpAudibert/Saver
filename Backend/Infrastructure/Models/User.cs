using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Backend.Infrastructure.Models;

public class User
{
    public ObjectId Id { get; set; } = default!;
    public required string Name { get; set; }
    public required string Email { get; set; }

    [JsonIgnore]
    public string Password { get; set; } = default!;
    public bool IsActive { get; set; }
}
