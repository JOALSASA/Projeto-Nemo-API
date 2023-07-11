using Projeto_Nemo.Models;

namespace Projeto_Nemo.Services.Interfaces
{
    public interface IUsuarioAquarioService
    {
        void PartilharAquarioComUsuario(int idAquario, int idUsuario);
        UsuarioAquario BuscarUsuarioAquarioPorIds(int idAquario, int idUsuario);
    }
}
