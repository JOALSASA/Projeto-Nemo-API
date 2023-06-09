using Projeto_Nemo.Models;

namespace Projeto_Nemo.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {

        Usuario Inserir(Usuario usuario);
        Usuario Alterar(Usuario usuario);
        void Excluir(Usuario usuario);
        Usuario? FindUsuarioById(int id);
        List<Usuario> FindUsuarioByNome(string name);
        Usuario? RecuperarPorEmail(string email);
        Usuario? FindUsuarioByName(string name);
    }
}