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
        }

        public Parametro? BuscarParametroPorTipo(TipoParametro tipoParametro)
        {
            return _dbContext.Parametros.FirstOrDefault(p => p.Tipo == tipoParametro);
        }

        public void ExcluirParametroDoAquario(AquarioParametro aquarioParametro)
        {
            _dbContext.AquarioParametros.Remove(aquarioParametro);
        }

        public AquarioParametro? BuscarAquarioParametro(int idAquarioParametro)
        {
            return _dbContext.AquarioParametros
                .Where(ap => ap.Id == idAquarioParametro).FirstOrDefault();
        }

        public List<AquarioParametro> ParametrosDoAquario(int idAquario)
        {
            return _dbContext.AquarioParametros
                .Include(ap => ap.Parametro)
                .Where(ap => ap.AquariosId == idAquario).ToList();
        }

        public void AtualizarParametro(AquarioParametro aquarioParametro)
        {
            _dbContext.AquarioParametros.Update(aquarioParametro);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}