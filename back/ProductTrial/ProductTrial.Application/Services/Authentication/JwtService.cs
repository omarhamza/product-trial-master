using Microsoft.IdentityModel.Tokens;
using ProductTrial.Application.Interfaces;
using ProductTrial.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductTrial.Application.Services.Authentication;

public class JwtService : IJwtService
{
    private readonly string _secretKey;
    private readonly string _issuer;

    public JwtService(string secretKey, string issuer)
    {
        _secretKey = secretKey;
        _issuer = issuer;
    }

    public string GenerateToken(string email)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, email),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _issuer,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(10),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
