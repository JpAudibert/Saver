using Backend.Users.Models;
using MongoDB.Bson;

namespace Backend.Users.Interfaces;

public interface IUserService
{
    Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(ObjectId id);
    Task<User?> AddAndUpdateUser(User userObj);
}
