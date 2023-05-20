using Projeto_Nemo.Models;

namespace Projeto_Nemo.Repositories.Interfaces
{
    public interface IPerfilRepository
    {
        List<Perfil> RecuperarTodosPerfis();
        List<Perfil> RecuperarPerfisUsuario(int idUsuario);
    }
}
