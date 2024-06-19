using Backend.Users.Interfaces;
using Backend.Users.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Users.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpPost]
    public async Task<IActionResult> Authenticate(AuthenticateRequest model)
    {
        var response = await _userService.Authenticate(model);

        if (response == null)
            return Unauthorized(new { message = "Username or password is incorrect" });

        return Ok(response);
    }
}
