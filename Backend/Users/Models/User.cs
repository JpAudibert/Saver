using Backend.Finances.Models;

namespace Backend.Users.Models;

public class User
{
    public Guid Id { get; set; } = default!;
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string IdentificationNumber { get; set; }
    public string Password { get; set; } = default!;
    public bool IsActive { get; set; }
    public IList<Finance> Finances { get; set; } = [];
}
