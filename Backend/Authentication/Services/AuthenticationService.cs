﻿using Backend.Authentication.Interfaces;
using Backend.Authentication.Models;
using Backend.EF;
using Backend.Users.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Authentication.Services;

public class AuthenticationService(IOptions<AppSettings> appSettings, SaverContext saverContext) : IAuthenticationService
{
    private readonly AppSettings _appSettings = appSettings.Value;
    private readonly SaverContext _saverContext = saverContext;

    public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
    {
        var user = await _saverContext.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        var token = await GenerateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    private async Task<string> GenerateJwtToken(User user)
    {
        //Generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = await Task.Run(() =>
        {

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([new Claim("id", user.Id.ToString())]),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.CreateToken(tokenDescriptor);
        });

        return tokenHandler.WriteToken(token);
    }
}
