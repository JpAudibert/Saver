using Backend.EF;
using Backend.Extensions;
using Backend.Users.Interfaces;
using Backend.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Users.Services;

public class UserService(IConfiguration configuration) : IUserService
{
    private readonly IConfiguration _configuration = configuration;
    public async Task<User?> AddUser(User userObj)
    {
        using SaverContext saverContext = new(_configuration);

        User newUser = new()
        {
            Id = Guid.NewGuid(),
            Email = userObj.Email,
            Name = userObj.Name.Capitalize(),
            Password = userObj.Password,
            IdentificationNumber = userObj.IdentificationNumber,
            IsActive = userObj.IsActive
        };

        await saverContext.Users.AddAsync(newUser);
        await saverContext.SaveChangesAsync();

        return newUser;
    }

    public async Task DeleteUser(Guid id)
    {
        using SaverContext saverContext = new(_configuration);

        await saverContext.Users.Where(user => user.Id == id).ExecuteDeleteAsync();
        await saverContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        using SaverContext saverContext = new(_configuration);

        return await saverContext.Users.ToListAsync();
    }

    public async Task<User?> GetUserById(Guid id)
    {
        using SaverContext saverContext = new(_configuration);

        return await saverContext.Users.FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<User?> UpdateUser(Guid id, User userObj)
    {
        using SaverContext saverContext = new(_configuration);

        var user = await saverContext.Users.SingleAsync(user => user.Id == id);
        user.Name = userObj.Name.Capitalize();
        user.Email = userObj.Email;
        user.Password = userObj.Password;
        user.IdentificationNumber = userObj.IdentificationNumber;
        user.IsActive = userObj.IsActive;

        await saverContext.SaveChangesAsync();

        return user;
    }
}
