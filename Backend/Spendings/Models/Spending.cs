using MongoDB.Bson;

namespace Backend.Spendings.Models;

public class Spending
{
    public ObjectId Id { get; set; }
    public double Amount { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }

    public Spending()
    {
        Id = ObjectId.GenerateNewId();
    }

    public Spending(double amount, string description, string type)
    {
        Id = ObjectId.GenerateNewId();
        Amount = amount;
        Description = description;
        Type = type;
    }
}
