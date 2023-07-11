using Projeto_Nemo.Models;

namespace Projeto_Nemo.Repositories.Interfaces;

public interface IAlertaRepository
{
    void AdicionarAlerta(Alerta novoAlerta);
    List<Alerta> ConsultarTodosOsAlertas();
    List<Alerta> ConsultarAlertasDoAquario(int idAquario);
    Alerta BuscarAlertaPeloId(int idAlerta);
    void AlterarAlerta(Alerta alerta);
    void ExcluirAlertaDoAquario(Alerta alerta);
}