using Backend.Infrastructure.Models;
using MongoDB.Bson;

namespace Backend.Infrastructure.Interfaces;

public interface IUserService
{
    Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(ObjectId id);
    Task<User?> AddAndUpdateUser(User userObj);
}
