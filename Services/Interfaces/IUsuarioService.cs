using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;

namespace Projeto_Nemo.Services.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioDto Inserir(NovoUsuarioForm novoUsuario);
        Usuario Alterar(Usuario usuario);
        bool Excluir(int id);
        UsuarioDto RecuperarPorId(int id);
        List<UsuarioDto> RecuperarPorNome(string nome);
        string Autenticar(LoginForm loginForm);
    }
}
