using Backend.Authentication.Filters;
using Backend.Finances.Interface;
using Backend.Finances.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Finances.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class FinancesController(IFinanceService financeService) : ControllerBase
{
    private readonly IFinanceService _financeService = financeService;

    [HttpGet]
    public ActionResult<IEnumerable<Finance>> GetAllFinances([FromHeader] string userId)
    {
        return Ok();
        //return Ok(_financeService.GetAllFinancesForUser(userId));
    }

    [HttpGet("financeId")]
    public ActionResult<Finance> GetFinance([FromHeader] string userId, string financeId)
    {
        return Ok();
        //return Ok(_financeService.GetFinanceForUser(userId, financeId));
    }

    [HttpPost]
    public ActionResult<Finance> PostFinances([FromHeader] string userId, [FromBody] Finance finance)
    {
        return Ok();
        //return Ok(_financeService.CreateFinanceForUser(userId, finance));
    }

    [HttpPut("financeId")]
    public ActionResult<Finance> PutFinances([FromHeader] string userId, string financeId, [FromBody] Finance finance)
    {
        return Ok();
        //return Ok(_financeService.UpdateFinanceForUser(userId, financeId, finance));
    }

    [HttpDelete("financeId")]
    public ActionResult DeleteFinances([FromHeader] string userId, string financeId)
    {
        //_financeService.DeleteFinanceForUser(userId, financeId);
        return Ok();
    }
}
