using Microsoft.EntityFrameworkCore;
using Projeto_Nemo.Data;
using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Enums;
using Projeto_Nemo.Repositories.Interfaces;

namespace Projeto_Nemo.Repositories
{
    public class ParametroRepository : IParametroRepository
    {

        private readonly NemoDbContext _dbContext;

        public ParametroRepository(NemoDbContext dbContext)
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

        public void ExcluirParametroDoAquario(AquarioParametro aquarioParametro)
        {
            _dbContext.AquarioParametros.Remove(aquarioParametro);
            _dbContext.SaveChanges();
        }

        public AquarioParametro? BuscarAquarioParametro(int idAquario, int idParametro)
        {
            return _dbContext.AquarioParametros.Where(ap => ap.AquariosId == idAquario && ap.ParametrosId == idParametro).FirstOrDefault();
            //return _dbContext.AquarioParametros.Where(ap => ap.Id.Equals(idAquarioParametro)).FirstOrDefault();
        }
    }
}
