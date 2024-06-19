using Backend.Helpers;
using Backend.Users.Interfaces;
using Backend.Users.Models;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Backend.Users.Services;

public class UserService(ILogger<UserService> logger, MongoProvider mongoProvider) : IUserService
{
    private readonly ILogger<UserService> _logger = logger;
    private readonly MongoProvider _mongoProvider = mongoProvider;

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _mongoProvider.UsersCollection.FindAsync(x => x.IsActive == true).Result.ToListAsync();
    }

    public async Task<User?> GetById(string id)
    {
        return await _mongoProvider.UsersCollection.FindAsync(x => x.RegularId == id).Result.FirstOrDefaultAsync();
    }

    public async Task<User?> AddAndUpdateUser(User userObj)
    {
        try
        {
            User? user = null;

            List<KeyValuePair<string, object>> filterDictionary = [
                new KeyValuePair<string, object>("RegularId", userObj.RegularId!),
            ];

            BsonDocument filter = new(filterDictionary);
            var update = Builders<User>.Update
                .Set(x => x.Name, userObj.Name)
                .Set(x => x.Email, userObj.Email)
                .Set(x => x.IdentificationNumber, userObj.IdentificationNumber)
                .Set(x => x.Password, userObj.Password)
                .Set(x => x.IsActive, userObj.IsActive);

            user = await _mongoProvider.UsersCollection.FindOneAndUpdateAsync(filter, update);

            if (user is not null)
            {
                return userObj;
            }

            if (userObj.RegularId.IsNullOrEmpty())
            {
                userObj.RegularId = Guid.NewGuid().ToString();
                await _mongoProvider.UsersCollection.InsertOneAsync(userObj);
                user = userObj;
            }

            return userObj;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding or updating user.");
            throw;
        }
    }

    public async Task<DeleteResult> DeleteUser(string id)
    {
        return await _mongoProvider.UsersCollection.DeleteOneAsync(x => x.RegularId == id);
    }
}
