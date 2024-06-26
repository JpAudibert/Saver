using Backend.Users.Models;
using System.Text.Json.Serialization;

namespace Backend.Finances.Models;

public class Finance
{
    public Guid Id { get; set; } = default!;
    public decimal Amount { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Type { get; set; } = default!;
    [JsonIgnore]
    public Guid? UserId { get; set; } = default!;
    [JsonIgnore]
    public User? User { get; set; } = default!;
}
