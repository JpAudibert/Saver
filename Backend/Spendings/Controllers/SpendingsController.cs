using Backend.Authentication.Filters;
using Backend.Spendings.Interface;
using Backend.Spendings.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Spendings.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class SpendingsController(ILogger<SpendingsController> logger, ISpendingService spendingRepository) : ControllerBase
{
    private readonly ILogger<SpendingsController> _logger = logger;
    private readonly ISpendingService _spendingRepository = spendingRepository;

    [HttpGet(Name = "spendings")]
    public ActionResult<IEnumerable<Spending>> GetAll([FromHeader] string userId)
    {
        return Ok(_spendingRepository.GetAllSpendings(userId));
    }

    [HttpGet(Name = "spendings")]
    public ActionResult<Spending> Get([FromHeader] string userId, [FromRoute] string spendingId)
    {
        return Ok(_spendingRepository.GetSpending(userId, spendingId));
    }

    [HttpPost(Name = "spendings")]
    public ActionResult<Spending> Post([FromHeader] string userId, [FromBody] Spending spending)
    {
        return Ok(_spendingRepository.CreateSpending(userId, spending));
    }

    [HttpPut(Name = "spendings")]
    public ActionResult<Spending> Put([FromHeader] string userId, [FromRoute] string spendingId, [FromBody] Spending spending)
    {
        return Ok(_spendingRepository.UpdateSpending(userId, spendingId, spending));
    }

    [HttpDelete(Name = "spendings")]
    public ActionResult Delete([FromHeader] string userId, [FromRoute] string spendingId)
    {
        _spendingRepository.DeleteSpending(userId, spendingId);
        return Ok();
    }
}
