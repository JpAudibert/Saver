using Backend.Users.Interfaces;
using Backend.Users.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Users.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly AppSettings _appSettings;
    private readonly IConfiguration _configuration;
    private readonly IMongoCollection<User> _usersCollection;

    public UserService(ILogger<UserService> logger, IOptions<AppSettings> appSettings, IConfiguration configuration)
    {
        _logger = logger;
        _appSettings = appSettings.Value;
        _configuration = configuration;
        string connectionUri = _configuration?.GetConnectionString("Saver") ?? default!;

        MongoClient client = new(connectionUri);
        IMongoDatabase database = client.GetDatabase("saver");

        _usersCollection = database.GetCollection<User>("users");
        _usersCollection.Indexes.CreateOne(new CreateIndexModel<User>(Builders<User>.IndexKeys.Ascending(x => x.Email), new CreateIndexOptions { Unique = true }));
        _usersCollection.Indexes.CreateOne(new CreateIndexModel<User>(Builders<User>.IndexKeys.Ascending(x => x.IdentificationNumber), new CreateIndexOptions { Unique = true }));
    }

    public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
    {
        var user = await _usersCollection.FindAsync(x => x.Email == model.Email && x.Password == model.Password).Result.FirstOrDefaultAsync();

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        var token = await GenerateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _usersCollection.FindAsync(x => x.IsActive == true).Result.ToListAsync();
    }

    public async Task<User?> GetById(string id)
    {
        return await _usersCollection.FindAsync(x => x.RegularId == id).Result.FirstOrDefaultAsync();
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

            user = await _usersCollection.FindOneAndUpdateAsync(filter, update);

            if (user is not null)
            {
                return userObj;
            }

            if (userObj.RegularId.IsNullOrEmpty())
            {
                userObj.RegularId = Guid.NewGuid().ToString();
                await _usersCollection.InsertOneAsync(userObj);
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
    
    private async Task<string> GenerateJwtToken(User user)
    {
        //Generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = await Task.Run(() =>
        {

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([new Claim("id", user.Id.ToString())]),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.CreateToken(tokenDescriptor);
        });

        return tokenHandler.WriteToken(token);
    }

    public async Task<DeleteResult> DeleteUser(string id)
    {
        return await _usersCollection.DeleteOneAsync(x => x.RegularId == id);
    }
}
