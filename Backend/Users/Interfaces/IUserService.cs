using Backend.Users.Models;

namespace Backend.Users.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUserById(Guid id);
    Task<User?> AddUser(User userObj);
    Task<User?> UpdateUser(Guid id, User userObj);
    Task DeleteUser(Guid id);
}
