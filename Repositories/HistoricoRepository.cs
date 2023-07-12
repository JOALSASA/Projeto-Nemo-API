using Microsoft.EntityFrameworkCore;
using Projeto_Nemo.Data;
using Projeto_Nemo.Models;
using Projeto_Nemo.Repositories.Interfaces;

namespace Projeto_Nemo.Repositories;

public class HistoricoRepository : IHistoricoRepository
{
    private readonly NemoDbContext _dbContext;

    public HistoricoRepository(NemoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void InserirHistorico(Historico historico)
    {
        _dbContext.Historicos.Add(historico);
    }

    public List<Historico> BuscarUltimosHistoricoAquarioParametro(int idAquarioParametro, DateTime dataLimite)
    {
        return _dbContext.Historicos
            .Include(historico => historico.Usuario)
            .Include(historico => historico.AquarioParametro)
            .Where(historico => historico.AquarioParametro.Id == idAquarioParametro && historico.Hora >= dataLimite)
            .ToList();
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
}