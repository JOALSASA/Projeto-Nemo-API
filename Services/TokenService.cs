using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Projeto_Nemo.Models;
using Projeto_Nemo.Repositories.Interfaces;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IPerfilRepository _perfilRepository;
    
    public TokenService(IConfiguration configuration, IPerfilRepository perfilRepository)
    {
        _configuration = configuration;
        _perfilRepository = perfilRepository;
    }
    
    public string GerarToken(Usuario usuario)
    {
        List<String> listaPerfis = _perfilRepository.RecuperarPerfisUsuario(usuario.Id).Select(p => p.Nome).ToList();
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
                new Claim("nome", usuario.NomeUsuario),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, string.Join(",", listaPerfis))
            })
        };
        var token = manipuladorToken.CreateToken(descritorToken);
        return manipuladorToken.WriteToken(token);
    }
}