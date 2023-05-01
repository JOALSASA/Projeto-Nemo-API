using Projeto_Nemo.Data;
using Projeto_Nemo.Models;
using Projeto_Nemo.Repositories.Interfaces;

namespace Projeto_Nemo.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly NemoDBContext _dbContext;

        public UsuarioRepository(NemoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Usuario Alterar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Excluir(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario FindUsuarioById(int id)
        {
            return _dbContext.Usuarios.Find(id);
        }

        public Usuario Inserir(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}