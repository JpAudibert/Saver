using Backend.Spendings.Interface;
using Backend.Spendings.Models;

namespace Backend.Spendings.Repositories;

public class SpendingService : ISpendingService
{
    public Spending CreateSpending(string userId, Spending spending)
    {
        throw new NotImplementedException();
    }

    public void DeleteSpending(string userId, string spendingId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Spending> GetAllSpendings(string userId)
    {
        throw new NotImplementedException();
    }

    public Spending GetSpending(string userId, string spendingId)
    {
        throw new NotImplementedException();
    }

    public Spending UpdateSpending(string userId, string spendingId, Spending spending)
    {
        throw new NotImplementedException();
    }
}
