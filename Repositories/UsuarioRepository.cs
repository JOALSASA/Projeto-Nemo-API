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

        public Task<Usuario> Alterar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Excluir(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> FindUsuarioById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> FindUsuarioByNome(string nome)
        {
            return _dbContext.Usuarios.Where(u => u.NomeUsuario.Contains(nome)).ToList();
        }

        public Task<Usuario> Inserir(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}