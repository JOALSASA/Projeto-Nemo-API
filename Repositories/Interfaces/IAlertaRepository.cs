using Projeto_Nemo.Models;

namespace Projeto_Nemo.Repositories.Interfaces;

public interface IAlertaRepository
{
    void AdicionarAlerta(Alerta novoAlerta);
    List<Alerta> ConsultarTodosOsAlertas();
    List<Alerta> ConsultarAlertasDoAquario(int idAquario);
    Alerta? BuscarAlertaPeloId(int idAlerta);
    List<Alerta> BuscarAlertaPeloIdAquarioParametro(int idAquarioParametro);
    void AlterarAlerta(Alerta alerta);
    void ExcluirAlertaDoAquario(List<Alerta> alertas);
    void SaveChanges();
}