using Microsoft.EntityFrameworkCore;
using Projeto_Nemo.Data;
using Projeto_Nemo.Models;
using Projeto_Nemo.Repositories.Interfaces;

namespace Projeto_Nemo.Repositories
{
    public class UsuarioAquarioRepository : IUsuarioAquarioRepository
    {
        private readonly NemoDbContext _dbContext;

        public UsuarioAquarioRepository(NemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void PartilharAquarioComUsuario(UsuarioAquario usuarioAquario)
        {
            _dbContext.UsuarioAquarios.Add(usuarioAquario);
            _dbContext.SaveChanges();
        }
        public UsuarioAquario? BuscarUsuarioAquarioPorIds(int idAquario, int idUsuario)
        {
            return _dbContext.UsuarioAquarios
                .Include(ua => ua.Aquario)
                .Include(ua => ua.Usuario)
                .FirstOrDefault(ua => ua.AquariosId == idAquario && ua.UsuariosId == idUsuario);
            //return _dbContext.UsuarioAquarios.Where(ua => ua.AquariosId == idAquario && ua.UsuariosId == idUsuario).FirstOrDefault();
        }
    }
}
