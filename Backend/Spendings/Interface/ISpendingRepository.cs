using Backend.Spendings.Models;
using MongoDB.Bson;

namespace Backend.Spendings.Interface;

public interface ISpendingRepository
{
    public IEnumerable<Spending> GetAllSpendings();
    public Spending GetSpending(ObjectId id);
    public Spending CreateSpending(Spending spending);
    public Spending UpdateSpending(ObjectId id, Spending spending);
    public void DeleteSpending(ObjectId id);
}
