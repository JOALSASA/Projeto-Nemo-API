using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;

namespace Projeto_Nemo.Services.Interfaces;

public interface IAlertaService
{
    void AdicionarAlerta(NovoAlertaForm novoAlertaForm);
    List<Alerta> ConsultarTodosOsAlertas();
    List<Alerta> ConsultarAlertasDoAquario(int idAquario);
    void AlterarAlerta(int idAlerta, NovoAlertaForm novoAlertaForm);
    void ExcluirAlertaDoAquario(int idAlerta);
}