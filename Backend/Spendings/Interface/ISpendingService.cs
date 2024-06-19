using Backend.Spendings.Models;
using MongoDB.Bson;

namespace Backend.Spendings.Interface;

public interface ISpendingService
{
    public IEnumerable<Spending> GetAllSpendings(string userId);
    public Spending GetSpending(string userId, string spendingId);
    public Spending CreateSpending(string userId, Spending spending);
    public Spending UpdateSpending(string userId, string spendingId, Spending spending);
    public void DeleteSpending(string userId, string spendingId);
}
