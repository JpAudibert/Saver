using Backend.Transactions.Models;

namespace Backend.Transactions.Interface;

public interface ITransactionService
{
    public IEnumerable<Transaction> GetAllTransactionsForUser(string userId);
    public Transaction GetTransactionForUser(string userId, string transactionId);
    public Transaction CreateTransactionForUser(string userId, Transaction transaction);
    public Transaction UpdateTransactionForUser(string userId, string transactionId, Transaction transaction);
    public void DeleteTransactionForUser(string userId, string transactionId);
}
