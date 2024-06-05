using Backend.Spendings.Interface;
using Backend.Spendings.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Backend.Spendings.Controllers;

[ApiController]
[Route("[controller]")]
public class SpendingsController(ILogger<SpendingsController> logger, ISpendingRepository spendingRepository) : ControllerBase
{
    private readonly ILogger<SpendingsController> _logger = logger;
    private readonly ISpendingRepository _spendingRepository = spendingRepository;

    [HttpGet(Name = "spendings")]
    public ActionResult<IEnumerable<Spending>> GetAll()
    {
        return Ok(_spendingRepository.GetAllSpendings());
    }

    [HttpGet(Name = "spendings")]
    public ActionResult<Spending> Get([FromRoute] ObjectId id)
    {
        return Ok(_spendingRepository.GetSpending(id));
    }

    [HttpPost(Name = "spendings")]
    public ActionResult<Spending> Post([FromBody] Spending spending)
    {
        return Ok(_spendingRepository.CreateSpending(spending));
    }

    [HttpPut(Name = "spendings")]
    public ActionResult<Spending> Put([FromRoute] ObjectId id, [FromBody] Spending spending)
    {
        return Ok(_spendingRepository.UpdateSpending(id, spending));
    }

    [HttpDelete(Name = "spendings")]
    public ActionResult Delete([FromRoute] ObjectId id)
    {
        _spendingRepository.DeleteSpending(id);
        return Ok();
    }
}
