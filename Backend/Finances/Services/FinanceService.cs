using Backend.Finances.Interface;
using Backend.Finances.Models;
using Backend.Users.Models;

namespace Backend.Finances.Services;

public class FinanceService() : IFinanceService
{
    public Task<User> CreateFinanceForUser(Guid userId, Finance finance)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteFinanceForUser(Guid userId, Guid financeId)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetAllFinancesForUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetFinanceForUser(Guid userId, Guid financeId)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateFinanceForUser(Guid userId, Guid financeId, Finance finance)
    {
        throw new NotImplementedException();
    }
}
