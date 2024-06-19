using Backend.Users.Models;
using MongoDB.Bson;

namespace Backend.Authentication.Models;

public class AuthenticateResponse(User user, string token)
{
    public ObjectId Id { get; set; } = user.Id;
    public string UserId { get; set; } = user.RegularId;
    public string Name { get; set; } = user.Name;
    public string Email { get; set; } = user.Email;
    public string Token { get; set; } = token;
}
