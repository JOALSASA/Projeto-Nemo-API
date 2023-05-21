using Projeto_Nemo.Models;

namespace Projeto_Nemo.Services.Interfaces;

public interface ITokenService
{
    public string GerarToken(Usuario usuario);
}