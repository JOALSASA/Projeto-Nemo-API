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
        _dbContext.SaveChanges();
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

    public void AlterarAlerta(Alerta alerta)
    {
        _dbContext.Alertas.Update(alerta);
        _dbContext.SaveChanges();
    }

    public void ExcluirAlertaDoAquario(Alerta alerta)
    {
        _dbContext.Alertas.Remove(alerta);
        _dbContext.SaveChanges();
    }
}