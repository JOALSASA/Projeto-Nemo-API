using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;

namespace Projeto_Nemo.Services.Interfaces
{
    public interface IUsuarioService
    {
        Usuario Inserir(Usuario usuario);
        Usuario Alterar(Usuario usuario);
        bool Excluir(NovoUsuarioForm usuario);
        Usuario FindUsuarioById(int id);
        Usuario FindUsuarioByNome(string nome);
    }
}
