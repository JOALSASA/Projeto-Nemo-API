using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Projeto_Nemo.Models;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string GerarToken(Usuario usuario)
    {
        var manipuladorToken = new JwtSecurityTokenHandler();
        
        var chave = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]!);
        var descritorToken = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature),
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Email)
            })
        };
        var token = manipuladorToken.CreateToken(descritorToken);
        return manipuladorToken.WriteToken(token);
    }
}