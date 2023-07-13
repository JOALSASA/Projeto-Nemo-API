using Microsoft.EntityFrameworkCore;
using Projeto_Nemo.Data;
using Projeto_Nemo.Models;
using Projeto_Nemo.Repositories.Interfaces;

namespace Projeto_Nemo.Repositories;

public class AlertaRepository : IAlertaRepository
{
    private readonly NemoDbContext _dbContext;

    public AlertaRepository(NemoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void AdicionarAlerta(Alerta novoAlerta)
    {
        _dbContext.Alertas.Add(novoAlerta);
    }

    public List<Alerta> ConsultarTodosOsAlertas()
    {
        return _dbContext.Alertas.Include(a => a.Aquario).Include(a => a.AquarioParametro.Parametro).ToList();
    }

    public List<Alerta> ConsultarAlertasDoAquario(int idAquario)
    {
        return _dbContext.Alertas.
            Include(a => a.Aquario).
            Include(a => a.AquarioParametro.Parametro).
            Where(a => a.Aquario.Id == idAquario).ToList();
    }

    public Alerta? BuscarAlertaPeloId(int idAlerta)
    {
       return _dbContext.Alertas.FirstOrDefault(a => a.Id == idAlerta);
    }

    public List<Alerta> BuscarAlertaPeloIdAquarioParametro(int idAquarioParametro)
    {
        return _dbContext.Alertas
            .Include(alerta => alerta.AquarioParametro)
            .Where(alerta => alerta.AquarioParametro.Id == idAquarioParametro)
            .ToList();
    }

    public void AlterarAlerta(Alerta alerta)
    {
        _dbContext.Alertas.Update(alerta);
    }

    public void ExcluirAlertaDoAquario(Alerta alerta)
    {
        _dbContext.Alertas.Remove(alerta);
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
}