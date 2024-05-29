using Backend.Spendings.Interface;
using Backend.Spendings.Models;

namespace Backend.Spendings.Services;

public class SpendingServiceArray : ISpendingService
{
    public IEnumerable<Spending> GetAllSpendings()
    {
        return [
            new Spending(10.0, "Bought a book", "Spending"),
            new Spending(20.0, "Bought a game", "Spending"),
            new Spending(30.0, "Bought a movie", "Income")
        ];
    }
}
