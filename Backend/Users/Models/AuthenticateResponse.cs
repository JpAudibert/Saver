﻿using MongoDB.Bson;

namespace Backend.Users.Models;

public class AuthenticateResponse(User user, string token)
{
    public ObjectId Id { get; set; } = user.Id;
    public string Name { get; set; } = user.Name;
    public string Email { get; set; } = user.Email;
    public string Token { get; set; } = token;
}