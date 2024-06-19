using Backend.Authentication.Filters;
using Backend.Transactions.Interface;
using Backend.Transactions.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Transactions.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class TransactionsController(ITransactionService transactionService) : ControllerBase
{
    private readonly ITransactionService _transactionService = transactionService;

    [HttpGet]
    public ActionResult<IEnumerable<Transaction>> GetAll([FromHeader] string userId)
    {
        return Ok(_transactionService.GetAllTransactionsForUser(userId));
    }

    [HttpGet]
    public ActionResult<Transaction> Get([FromHeader] string userId, [FromRoute] string transactionId)
    {
        return Ok(_transactionService.GetTransactionForUser(userId, transactionId));
    }

    [HttpPost]
    public ActionResult<Transaction> Post([FromHeader] string userId, [FromBody] Transaction transaction)
    {
        return Ok(_transactionService.CreateTransactionForUser(userId, transaction));
    }

    [HttpPut]
    public ActionResult<Transaction> Put([FromHeader] string userId, [FromRoute] string transactionId, [FromBody] Transaction transaction)
    {
        return Ok(_transactionService.UpdateTransactionForUser(userId, transactionId, transaction));
    }

    [HttpDelete]
    public ActionResult Delete([FromHeader] string userId, [FromRoute] string transactionId)
    {
        _transactionService.DeleteTransactionForUser(userId, transactionId);
        return Ok();
    }
}
