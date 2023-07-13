using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;

namespace Projeto_Nemo.Services.Interfaces
{
    public interface IUsuarioAquarioService
    {
        void PartilharAquarioComUsuario(int idAquario, int idUsuario);
        UsuarioAquario BuscarUsuarioAquarioPorIds(int idAquario, int idUsuario);
        List<UsuarioAquario> BuscarTodosUsuariosPermissao(int idAquario);
        void ExcluirUsuarioAutorizado(int idAquario, int idUsuario);
    }
}
