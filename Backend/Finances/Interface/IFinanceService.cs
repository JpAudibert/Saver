using Backend.Finances.Models;
using Backend.Users.Models;

namespace Backend.Finances.Interface;

public interface IFinanceService
{
    public Task<User> GetAllFinancesForUser(Guid userId);
    public Task<User> GetFinanceForUser(Guid userId, Guid financeId);
    public Task<User> CreateFinanceForUser(Guid userId, Finance finance);
    public Task<User> UpdateFinanceForUser(Guid userId, Guid financeId, Finance finance);
    public Task<User> DeleteFinanceForUser(Guid userId, Guid financeId);
}
