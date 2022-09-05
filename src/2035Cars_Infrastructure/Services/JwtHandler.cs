using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using _2035Cars_Infrastructure.DTO;
using _2035Cars_Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace _2035Cars_Infrastructure.Services;

public class JwtHandler : IJwtHandler
{
    private readonly IConfiguration _configuration;
    public JwtHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public JwtDTO CreateToken(Guid id, string emailAdress)
    {
        var now = DateTime.UtcNow;
        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, id.ToString()),
            new Claim(ClaimTypes.Email, emailAdress),
            //   new Claim(ClaimTypes.Role, role.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString())
        };

        var expires = now.AddMinutes(double.Parse(_configuration["JwtAuthentication:JwtExpireMinutes"]));

        var expiresss = _configuration["JwtAuthentication:JwtKey"];


        var signingCredentials = new SigningCredentials(
                                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                                                        (_configuration["JwtAuthentication:JwtKey"])),
                                    SecurityAlgorithms.HmacSha512);


        var jwt = new JwtSecurityToken(
                issuer: _configuration["JwtAuthentication:JwtIssuer"],
                audience: _configuration["JwtAuthentication:JwtAudience"],
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new JwtDTO()
        {
            Token = token,
            Expires = expires.ToTimestamp()
        };
    }
}