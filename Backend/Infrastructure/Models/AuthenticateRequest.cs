﻿using System.ComponentModel;

namespace Backend.Infrastructure.Models;

public class AuthenticateRequest
{
    [DefaultValue("System")]
    public required string Email { get; set; }

    [DefaultValue("System")]
    public required string Password { get; set; }
}