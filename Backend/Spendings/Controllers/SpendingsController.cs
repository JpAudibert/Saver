using Microsoft.AspNetCore.Mvc;
using Backend.Spendings.Models;
using Backend.Spendings.Interface;

namespace Backend.Spendings.Controllers;

[ApiController]
[Route("[controller]")]
public class SpendingsController : ControllerBase
{
    private readonly ILogger<SpendingsController> _logger;
    private readonly ISpendingService _spendingService;

    public SpendingsController(ILogger<SpendingsController> logger, ISpendingService spendingService)
    {
        _logger = logger;
        _spendingService = spendingService;
    }

    [HttpGet(Name = "spendings")]
    public IEnumerable<Spending> Get()
    {
        return _spendingService.GetAllSpendings();
    }
}
