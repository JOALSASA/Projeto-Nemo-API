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

        public Task<List<Aquario>> RecuperarPorUsuarioId(int id)
        {
            throw new NotImplementedException();
        }

        public Aquario Inserir(Aquario aquario)
        {
            _dbContext.Add(aquario);
            _dbContext.SaveChanges();
            return aquario;
        }
    }
}
