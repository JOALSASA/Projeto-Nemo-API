using Projeto_Nemo.Models;

namespace Projeto_Nemo.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Inserir(Usuario usuario);
        Usuario Alterar(Usuario usuario);
        Usuario Excluir(Usuario usuario);
        Usuario FindUsuarioById(int id);
    }
}