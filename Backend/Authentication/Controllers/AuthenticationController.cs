using Backend.Authentication.Interfaces;
using Backend.Authentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Authentication.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    private readonly IAuthenticationService _authenticationService = authenticationService;

    [HttpPost]
    public async Task<IActionResult> Authenticate(AuthenticateRequest model)
    {
        var response = await _authenticationService.Authenticate(model);

        if (response == null)
            return Unauthorized(new { message = "Username or password is incorrect" });

        return Ok(response);
    }
}
