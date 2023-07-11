using Projeto_Nemo.Models;

namespace Projeto_Nemo.Repositories.Interfaces
{
    public interface IUsuarioAquarioRepository
    {
        void PartilharAquarioComUsuario(UsuarioAquario usuarioAquario);
        UsuarioAquario? BuscarUsuarioAquarioPorIds(int idAquario, int idUsuario);
    }
}
