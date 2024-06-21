using Backend.EF;
using Backend.Users.Interfaces;
using Backend.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Users.Services;

public class UserService(SaverContext saverContext) : IUserService
{
    private SaverContext _saverContext = saverContext;

    public async Task<User?> AddUser(User userObj)
    {
        await _saverContext.Users.AddAsync(userObj);
        await _saverContext.SaveChangesAsync();

        return userObj;
    }

    public async Task DeleteUser(Guid id)
    {
        await _saverContext.Users.Where(user => user.Id == id).ExecuteDeleteAsync();
        await _saverContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _saverContext.Users.ToListAsync();
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await _saverContext.Users.FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<User?> UpdateUser(Guid id, User userObj)
    {
        User? user = await _saverContext.Users.FirstOrDefaultAsync(user => user.Id == id);

        User toUpdateUser = new()
        {
            Id = id,
            Email = userObj.Email,
            Name = userObj.Name,
            Password = userObj.Password,
            IsActive = userObj.IsActive,
            IdentificationNumber = userObj.IdentificationNumber
        };

        user = toUpdateUser;

        _saverContext.Users.Update(user);

        await _saverContext.SaveChangesAsync();

        return toUpdateUser;
    }
}
