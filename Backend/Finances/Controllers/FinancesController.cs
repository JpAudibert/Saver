using Backend.Authentication.Filters;
using Backend.Finances.Interface;
using Backend.Finances.Models;
using Backend.Users.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Finances.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class FinancesController(IFinanceService financeService) : ControllerBase
{
    private readonly IFinanceService _financeService = financeService;

    [HttpGet]
    public async Task<ActionResult<Finance>> GetAllFinances([FromHeader] Guid userId)
    {
        return Ok(await _financeService.GetAllFinancesForUser(userId));
    }

    [HttpGet("{financeId}")]
    public async Task<ActionResult<Finance>> GetFinance([FromHeader] Guid userId, Guid financeId)
    {
        return Ok(await _financeService.GetFinanceForUser(userId, financeId));
    }

    [HttpPost]
    public async Task<ActionResult<Finance>> PostFinances([FromHeader] Guid userId, [FromBody] Finance finance)
    {
        return Ok(await _financeService.CreateFinanceForUser(userId, finance));
    }

    [HttpPut("{financeId}")]
    public async Task<ActionResult<User>> PutFinances([FromHeader] Guid userId, Guid financeId, [FromBody] Finance finance)
    {
        return Ok(await _financeService.UpdateFinanceForUser(userId, financeId, finance));
    }

    [HttpDelete("{financeId}")]
    public async Task<ActionResult> DeleteFinances([FromHeader] Guid userId, Guid financeId)
    {
        await _financeService.DeleteFinanceForUser(userId, financeId);
        return Ok();
    }
}
