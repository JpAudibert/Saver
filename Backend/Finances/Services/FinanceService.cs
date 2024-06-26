using Backend.EF;
using Backend.Extensions;
using Backend.Finances.Interface;
using Backend.Finances.Models;
using Backend.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Finances.Services;

public class FinanceService(IConfiguration configuration) : IFinanceService
{
    public readonly IConfiguration _configuration = configuration;

    public async Task<Finance> CreateFinanceForUser(Guid userId, Finance finance)
    {
        using SaverContext saverContext = new(_configuration);

        var user = await saverContext.Users.Include(user => user.Finances).FirstOrDefaultAsync(user => user.Id == userId) ?? throw new Exception("User not found");

        var newFinance = new Finance
        {
            Id = Guid.NewGuid(),
            Amount = finance.Amount,
            Description = finance.Description.Capitalize(),
            Type = finance.Type,
            UserId = userId
        };

        user.Finances.Add(newFinance);

        await saverContext.Finances.AddAsync(newFinance);
        await saverContext.SaveChangesAsync();

        return newFinance;
    }

    public async Task DeleteFinanceForUser(Guid userId, Guid financeId)
    {
        using SaverContext saverContext = new(_configuration);

        User user = await saverContext.Users.Include(user => user.Finances).FirstOrDefaultAsync(user => user.Id == userId) ?? throw new Exception("User not found");
        Finance finance = user.Finances?.FirstOrDefault(finance => finance.Id == financeId) ?? throw new Exception("Finance not found");

        user.Finances.Remove(finance);
        await saverContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Finance>> GetAllFinancesForUser(Guid userId)
    {
        using SaverContext saverContext = new(_configuration);

        User user = await saverContext.Users.Include(user => user.Finances).FirstOrDefaultAsync(user => user.Id == userId) ?? throw new Exception("User not found");

        return user.Finances;
    }

    public async Task<Finance?> GetFinanceForUser(Guid userId, Guid financeId)
    {
        using SaverContext saverContext = new(_configuration);

        User user = await saverContext.Users.Include(user => user.Finances).FirstOrDefaultAsync(user => user.Id == userId) ?? throw new Exception("User not found");

        return user.Finances.FirstOrDefault(finance => finance.Id == financeId);
    }

    public async Task<Finance> UpdateFinanceForUser(Guid userId, Guid financeId, Finance finance)
    {
        using SaverContext saverContext = new(_configuration);

        User user = await saverContext.Users.Include(user => user.Finances).FirstOrDefaultAsync(user => user.Id == userId) ?? throw new Exception("User not found");
        Finance financeToUpdate = user.Finances?.FirstOrDefault(finance => finance.Id == financeId) ?? throw new Exception("User not found");

        financeToUpdate.Amount = finance.Amount;
        financeToUpdate.Description = finance.Description.Capitalize();
        financeToUpdate.Type = finance.Type;

        await saverContext.SaveChangesAsync();

        return financeToUpdate;
    }
}
