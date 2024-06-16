using Backend.Infrastructure.Interfaces;
using Backend.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Backend.Infrastructure.Controllers;

public class AuthController(IUserService userService) : ControllerBase
{
    private IUserService _userService = userService;

    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest model)
    {
        var response = await _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    // POST api/<CustomerController>
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post([FromBody] User userObj)
    {
        userObj.Id = ObjectId.Empty;
        return Ok(await _userService.AddAndUpdateUser(userObj));
    }

    // PUT api/<CustomerController>/5
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Put(ObjectId id, [FromBody] User userObj)
    {
        userObj.Id = id;
        return Ok(await _userService.AddAndUpdateUser(userObj));
    }
}
