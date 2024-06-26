using Backend.Finances.Models;
using Backend.Users.Models;

namespace Backend.Finances.Interface;

public interface IFinanceService
{
    public Task<IEnumerable<Finance>> GetAllFinancesForUser(Guid userId);
    public Task<Finance?> GetFinanceForUser(Guid userId, Guid financeId);
    public Task<Finance> CreateFinanceForUser(Guid userId, Finance finance);
    public Task<Finance> UpdateFinanceForUser(Guid userId, Guid financeId, Finance finance);
    public Task DeleteFinanceForUser(Guid userId, Guid financeId);
}
