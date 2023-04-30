using Projeto_Nemo.Models;

namespace Projeto_Nemo.Repositories.Interfaces
{
    public interface IAquarioRepository
    {
        Task<Aquario> Inserir(Aquario aquario);
        Task<Aquario> Alterar(Aquario aquario);
        Task<Aquario> Excluir(Aquario aquario);
        Task<Aquario> FindAquarioById(int id);
        Task<List<Aquario>> FindAquarioByUsuarioId(int id);
    }
}
