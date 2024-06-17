using System.ComponentModel;

namespace Backend.Infrastructure.Models;

public class AuthenticateRequest
{
    [DefaultValue("name@mail.com")]
    public required string Email { get; set; }

    [DefaultValue("password")]
    public required string Password { get; set; }
}
