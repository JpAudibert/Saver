using Backend.Users.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Backend.Users.Interfaces;

public interface IUserService
{
    Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(string id);
    Task<User?> AddAndUpdateUser(User userObj);
    Task<DeleteResult> DeleteUser(string id);
}
