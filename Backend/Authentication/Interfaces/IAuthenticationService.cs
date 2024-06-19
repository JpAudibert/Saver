using Backend.Authentication.Models;

namespace Backend.Authentication.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
}
