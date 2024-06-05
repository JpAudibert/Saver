using Backend.Spendings.Interface;
using Backend.Spendings.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Backend.Spendings.Repositories;

public class SpendingsRepository : ISpendingRepository
{
    public static MongoClient client = new(connectionUri);
    public static IMongoDatabase database = client.GetDatabase("saver");
    public static IMongoCollection<Spending> savingCollection = database.GetCollection<Spending>("savings");

    public const string connectionUri = "mongodb+srv://saver:#Savermanager123@saverdb.hkum5ju.mongodb.net/?retryWrites=true&w=majority&appName=SaverDB";

    public Spending CreateSpending(Spending spending)
    {
        savingCollection.InsertOne(spending);
        return spending;
    }

    public void DeleteSpending(ObjectId id)
    {
        savingCollection.DeleteOne(spending => spending.Id == id);
    }

    public IEnumerable<Spending> GetAllSpendings()
    {
        return savingCollection.Find(spending => true).ToList();
    }

    public Spending GetSpending(ObjectId id)
    {
        return savingCollection.Find(spending => spending.Id == id).FirstOrDefault();
    }

    public Spending UpdateSpending(ObjectId id, Spending spending)
    {
        savingCollection.ReplaceOne(spending => spending.Id == id, spending);
        return spending; 
    }
}
