using MongoDB.Bson;

namespace Backend.Spendings.Models;

public class Spending
{
    public ObjectId Id { get; set; } = default!;
    public string RegularId { get; set; } = default!;
    public double Amount { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Type { get; set; } = default!;
}
