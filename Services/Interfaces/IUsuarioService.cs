using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;

namespace Projeto_Nemo.Services.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioDto Inserir(NovoUsuarioForm novoUsuario);
        UsuarioDto Alterar(int id, EditarUsuarioForm editarUsuario);
        Usuario Excluir(Usuario usuario);
        Usuario RecuperarPorId(int id);
        List<UsuarioDto> RecuperarPorNome(string nome);
        string Autenticar(LoginForm loginForm);
    }
}
