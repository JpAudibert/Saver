using Backend.Transactions.Interface;
using Backend.Transactions.Models;

namespace Backend.Transactions.Repositories;

public class TransactionService : ITransactionService
{
    public Transaction CreateTransactionForUser(string userId, Transaction transaction)
    {
        throw new NotImplementedException();
    }

    public void DeleteTransactionForUser(string userId, string transactionId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetAllTransactionsForUser(string userId)
    {
        throw new NotImplementedException();
    }

    public Transaction GetTransactionForUser(string userId, string transactionId)
    {
        throw new NotImplementedException();
    }

    public Transaction UpdateTransactionForUser(string userId, string transactionId, Transaction transaction)
    {
        throw new NotImplementedException();
    }
}
