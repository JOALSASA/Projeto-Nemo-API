using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;

namespace Projeto_Nemo.Services.Interfaces
{
    public interface IUsuarioService
    {
        Usuario Inserir(Usuario usuario);
        Usuario Alterar(Usuario usuario);
        Usuario Excluir(Usuario usuario);
        Usuario FindUsuarioById(int id);
        List<UsuarioDto> FindUsuarioByNome(string nome);
    }
}
