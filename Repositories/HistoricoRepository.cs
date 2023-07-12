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

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
}