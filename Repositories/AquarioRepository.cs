using Projeto_Nemo.Data;
using Projeto_Nemo.Models;
using Projeto_Nemo.Repositories.Interfaces;

namespace Projeto_Nemo.Repositories
{
    public class AquarioRepository : IAquarioRepository
    {
        private readonly NemoDbContext _dbContext;

        public AquarioRepository(NemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Aquario> Alterar(Aquario aquario)
        {
            throw new NotImplementedException();
        }

        public Task<Aquario> Excluir(Aquario aquario)
        {
            throw new NotImplementedException();
        }

        public Task<Aquario> RecuperarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Aquario> RecuperarPorUsuarioId(int id/*, string nomeAquario*/)
        {
            /*if (nomeAquario != null)
            {
                return _dbContext.Aquarios.Where(u => u.Usuario.Id == id & u.Nome.Contains(nomeAquario)).ToList();
            }*/
            return _dbContext.Aquarios.Where(u => u.Usuario.Id == id).ToList();
        }

        public Task<Aquario> Inserir(Aquario aquario)
        {
            throw new NotImplementedException();
        }
    }
}
