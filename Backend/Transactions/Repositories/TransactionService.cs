using Backend.Helpers;
using Backend.Transactions.Interface;
using Backend.Transactions.Models;
using Backend.Users.Models;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace Backend.Transactions.Repositories;

public class TransactionService(MongoProvider mongoProvider) : ITransactionService
{
    private readonly MongoProvider _mongoProvider = mongoProvider;

    public async Task<User> CreateTransactionForUser(string userId, Transaction transaction)
    {
        List<Transaction> transactionList = [];
        transactionList.Add(transaction);

        var filter = Builders<User>.Filter.Eq(user => user.RegularId, userId);
        var update = Builders<User>.Update.Set(user => user.Transactions, transactionList);
        UpdateResult result = await _mongoProvider.UsersCollection.UpdateOneAsync(filter, update);

        User user = await _mongoProvider.UsersCollection.FindAsync(filter).Result.FirstOrDefaultAsync();

        return user;
    }

    public Task<User> DeleteTransactionForUser(string userId, string transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetAllTransactionsForUser(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetTransactionForUser(string userId, string transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateTransactionForUser(string userId, string transactionId, Transaction transaction)
    {
        throw new NotImplementedException();
    }
}
