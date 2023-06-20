using Microsoft.EntityFrameworkCore;
using Projeto_Nemo.Data;
using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Enums;
using Projeto_Nemo.Repositories.Interfaces;

namespace Projeto_Nemo.Repositories
{
    public class AquarioParametroRepository : IAquarioParametroRepository
    {

        private readonly NemoDbContext _dbContext;

        public AquarioParametroRepository(NemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AdicionarParametroAoAquario(AquarioParametro aquarioParametro)
        {
            _dbContext.AquarioParametros.Add(aquarioParametro);
            _dbContext.SaveChanges();
        }

        public Parametro? BuscarParametroPorTipo(TipoParametro tipoParametro)
        {
            return _dbContext.Parametros.FirstOrDefault(p => p.Tipo == tipoParametro);
        }
    }
}
