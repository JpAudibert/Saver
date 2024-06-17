using Backend.Infrastructure.Interfaces;
using Backend.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController: ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

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
        userObj.Id = ObjectId.Empty;
        return Ok(await _userService.AddAndUpdateUser(userObj));
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Put(ObjectId id, [FromBody] User userObj)
    {
        userObj.Id = id;
        return Ok(await _userService.AddAndUpdateUser(userObj));
    }
}
