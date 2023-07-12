using Projeto_Nemo.Models;

namespace Projeto_Nemo.Repositories.Interfaces;

public interface IHistoricoRepository
{
    void InserirHistorico(Historico historico);
    List<Historico> BuscarUltimosHistoricoAquarioParametro(int idAquarioParametro,  DateTime dataLimite);
    void SaveChanges();
}