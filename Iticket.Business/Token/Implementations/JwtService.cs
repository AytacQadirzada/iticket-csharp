using Iticket.Business.Token.Interfaces;
using Iticket.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Iticket.Business.Token.Implementations;

public class JwtService : IJwtService
{
    private readonly IConfiguration _config;
    public JwtService(IConfiguration config)
    {
        _config = config;
    }

    public string GetJwt(User user, IList<string> roles)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName),
            new Claim(ClaimTypes.Email, user.Email),
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        var expiresDate = DateTime.UtcNow.AddHours(4).AddMonths(1);

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:securityKey").Value));
        SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);
        JwtSecurityToken securityToken = new(
            issuer: _config.GetSection("Jwt:issuer").Value,
            audience: _config.GetSection("Jwt:audience").Value,
            claims: claims,
            expires: expiresDate,
            signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

}