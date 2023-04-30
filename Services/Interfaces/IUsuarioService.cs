using Projeto_Nemo.Models.Dto;

namespace Projeto_Nemo.Services.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioDto cadastrarNovoUsuario(NovoUsuarioForm novoUsuario);
    }
}
