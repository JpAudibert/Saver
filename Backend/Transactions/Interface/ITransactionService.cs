using Backend.Transactions.Models;
using Backend.Users.Models;

namespace Backend.Transactions.Interface;

public interface ITransactionService
{
    public Task<User> GetAllTransactionsForUser(string userId);
    public Task<User> GetTransactionForUser(string userId, string transactionId);
    public Task<User> CreateTransactionForUser(string userId, Transaction transaction);
    public Task<User> UpdateTransactionForUser(string userId, string transactionId, Transaction transaction);
    public Task<User> DeleteTransactionForUser(string userId, string transactionId);
}
