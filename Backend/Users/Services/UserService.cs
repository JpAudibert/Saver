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
    private readonly AppSettings _appSettings;
    private readonly IConfiguration _configuration;
    private readonly IMongoCollection<User> _usersCollection;

    public UserService(IOptions<AppSettings> appSettings, IConfiguration configuration)
    {
        _appSettings = appSettings.Value;
        _configuration = configuration;
        string connectionUri = _configuration?.GetConnectionString("Saver") ?? default!;

        MongoClient client = new(connectionUri);
        IMongoDatabase database = client.GetDatabase("saver");

        _usersCollection = database.GetCollection<User>("users");
    }

    public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
    {
        var user = await _usersCollection.FindAsync(x => x.Email == model.Email && x.Password == model.Password).Result.FirstOrDefaultAsync();

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        var token = await generateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _usersCollection.FindAsync(x => x.IsActive == true).Result.ToListAsync();
    }

    public async Task<User?> GetById(ObjectId id)
    {
        return await _usersCollection.FindAsync(x => x.Id == id).Result.FirstOrDefaultAsync();
    }

    public async Task<User?> AddAndUpdateUser(User userObj)
    {
        bool isSuccess = false;
        if (userObj.Id != ObjectId.Empty)
        {
            User? user = await _usersCollection.FindOneAndReplaceAsync(c => c.Id == userObj.Id, userObj);
            isSuccess = user != null;
        }
        else
        {
            await _usersCollection.InsertOneAsync(userObj);
            isSuccess = true;
        }

        return isSuccess ? userObj : null;
    }
    // helper methods
    private async Task<string> generateJwtToken(User user)
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
}
