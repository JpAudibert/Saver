using Backend.Users.Interfaces;
using Backend.Users.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Backend.Users.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest model)
    {
        var response = await _userService.Authenticate(model);

        if (response == null)
            return Unauthorized(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User userObj)
    {
        return Ok(await _userService.AddAndUpdateUser(userObj));
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] User userObj)
    {
        userObj.RegularId = id;
        return Ok(await _userService.AddAndUpdateUser(userObj));
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        return Ok(await _userService.DeleteUser(id));
    }
}
