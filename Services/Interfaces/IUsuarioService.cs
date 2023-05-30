using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;

namespace Projeto_Nemo.Services.Interfaces
{
    public interface IUsuarioService
    {
        Usuario Inserir(NovoUsuarioForm novoUsuario);
        void Excluir(int id);
        Usuario Alterar(int id, EditarUsuarioForm editarUsuario);
        Usuario RecuperarPorId(int id);
        List<Usuario> RecuperarPorNome(string nome);
        string Autenticar(LoginForm loginForm);
    }
}
