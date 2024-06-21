using Backend.Users.Models;

namespace Backend.Finances.Models;

public class Finance
{
    public Guid Id { get; set; } = default!;
    public decimal Amount { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Type { get; set; } = default!;
    public User? User { get; set; }
}
