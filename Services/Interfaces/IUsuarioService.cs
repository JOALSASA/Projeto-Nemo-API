using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;

namespace Projeto_Nemo.Services.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioDto Inserir(NovoUsuarioForm novoUsuario);
        UsuarioDto Alterar(int id, EditarUsuarioForm editarUsuario);
        Usuario Excluir(Usuario usuario);
        UsuarioDto FindUsuarioById(int id);
        List<UsuarioDto> FindUsuarioByNome(string nome);
    }
}
