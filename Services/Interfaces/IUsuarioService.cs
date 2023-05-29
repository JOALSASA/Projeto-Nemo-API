using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;

namespace Projeto_Nemo.Services.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioDto Inserir(NovoUsuarioForm novoUsuario);
        void Excluir(int id);
        UsuarioDto Alterar(int id, EditarUsuarioForm editarUsuario);
        Usuario RecuperarPorId(int id);
        List<UsuarioDto> RecuperarPorNome(string nome);
        string Autenticar(LoginForm loginForm);
    }
}
