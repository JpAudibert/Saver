using MongoDB.Bson;

namespace Backend.Transactions.Models;

public class Transaction
{
    public ObjectId Id { get; set; } = default!;
    public string RegularId { get; set; } = default!;
    public decimal Amount { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Type { get; set; } = default!;
}
