using Backend.Spendings.Models;

namespace Backend.Spendings.Interface;

public interface ISpendingService
{
    public IEnumerable<Spending> GetAllSpendings();
}
