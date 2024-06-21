using Backend.Users.Interfaces;
using Backend.Users.Models;

namespace Backend.Users.Services;

public class UserService() : IUserService
{
    public Task<User?> AddUser(User userObj)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> UpdateUser(Guid id, User userObj)
    {
        throw new NotImplementedException();
    }
}
