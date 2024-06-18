using Backend.Users.Interfaces;
using Backend.Users.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Backend.Helpers;

public class JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
{
    private readonly RequestDelegate _next = next;
    private readonly AppSettings _appSettings = appSettings.Value;

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
        if (token != null)
            AttachUserToContext(context, userService, token);

        await _next(context);
    }

    private void AttachUserToContext(HttpContext context, IUserService userService, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = jwtToken.Claims.First(x => x.Type == "regularId").Value.ToString();
            

            // attach user to context on successful jwt validation
            context.Items["User"] = userService.GetById(userId);
        }
        catch(Exception e)
        {
            Console.WriteLine($"An error happened due to {e.Message}", e);
        }
    }
}
