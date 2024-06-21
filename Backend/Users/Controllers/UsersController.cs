using Backend.Users.Interfaces;
using Backend.Users.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Users.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User userObj)
    {
        try
        {
            return Ok(await _userService.AddUser(userObj));
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] User userObj)
    {
        try
        {
            return Ok(await _userService.UpdateUser(id, userObj));
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _userService.GetUserById(id));
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _userService.DeleteUser(id);
        return Ok();
    }
}
