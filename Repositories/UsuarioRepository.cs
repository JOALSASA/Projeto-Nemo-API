using Projeto_Nemo.Data;
using Projeto_Nemo.Models;
using Projeto_Nemo.Repositories.Interfaces;

namespace Projeto_Nemo.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly NemoDbContext _dbContext;

        public UsuarioRepository(NemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Usuario Alterar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Usuario usuario)
        {
            _dbContext.Usuarios.Remove(usuario);
            _dbContext.SaveChanges();
        }

        public Usuario? FindUsuarioById(int id)
        {
            return _dbContext.Usuarios.Find(id);
        }
        
        public List<Usuario> FindUsuarioByNome(string nome)
        {
            return _dbContext.Usuarios.Where(u => u.NomeUsuario.Contains(nome)).ToList();
        }

        public Usuario? RecuperarPorEmail(string email)
        {
            return _dbContext.Usuarios.FirstOrDefault(u => u.Email.Equals(email));
        }

        public Usuario Inserir(Usuario usuario)
        {
            _dbContext.Add(usuario);
            _dbContext.SaveChanges();
            return usuario;
        }
    }
}