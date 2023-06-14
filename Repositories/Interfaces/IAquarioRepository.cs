using Projeto_Nemo.Models;

namespace Projeto_Nemo.Repositories.Interfaces
{
    public interface IAquarioRepository
    {
        Aquario Inserir(Aquario aquario);
        Aquario Alterar(Aquario aquario);
        Task<Aquario> Excluir(Aquario aquario);
        Aquario? RecuperarPorId(int id);
        List<Aquario> RecuperarPorUsuarioId(int id, string? nomeAquario);
        void CadastrarParametro (AquarioParametro aquarioParametro);
    }
}
