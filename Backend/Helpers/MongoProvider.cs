using Backend.Users.Models;
using MongoDB.Driver;

namespace Backend.Helpers;

public class MongoProvider
{
    private readonly IConfiguration _configuration = default!;
    public IMongoCollection<User> UsersCollection { get; } = default!;

    public MongoProvider(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionUri = _configuration?.GetConnectionString("Saver") ?? default!;

        MongoClient client = new(connectionUri);
        IMongoDatabase database = client.GetDatabase("saver");

        UsersCollection = database.GetCollection<User>("users");
        UsersCollection.Indexes.CreateOne(new CreateIndexModel<User>(Builders<User>.IndexKeys.Ascending(x => x.RegularId), new CreateIndexOptions { Unique = true }));
        UsersCollection.Indexes.CreateOne(new CreateIndexModel<User>(Builders<User>.IndexKeys.Ascending(x => x.Email), new CreateIndexOptions { Unique = true }));
        UsersCollection.Indexes.CreateOne(new CreateIndexModel<User>(Builders<User>.IndexKeys.Ascending(x => x.IdentificationNumber), new CreateIndexOptions { Unique = true }));
    }

}
