using Backend.Users.Models;
using MongoDB.Driver;

namespace Backend.Users.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(string id);
    Task<User?> AddAndUpdateUser(User userObj);
    Task<DeleteResult> DeleteUser(string id);
}
