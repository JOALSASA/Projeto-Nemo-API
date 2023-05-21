using System.Net;
using Microsoft.EntityFrameworkCore;
using Projeto_Nemo.Data;
using Projeto_Nemo.Exceptions;
using Projeto_Nemo.Models;
using Projeto_Nemo.Repositories.Interfaces;

namespace Projeto_Nemo.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly NemoDbContext _dbContext;

        public PerfilRepository(NemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Perfil> RecuperarPerfisUsuario(int idUsuario)
        {
            Usuario? usuario = _dbContext.Usuarios
                .Include(usuario => usuario.Perfis)
                .FirstOrDefault(usuario => usuario.Id == idUsuario);
            if (usuario == null)
            {
                throw new AppException("Não encontrei", HttpStatusCode.NotFound);
            }

            return usuario.Perfis;
        }

        public List<Perfil> RecuperarTodosPerfis()
        {
            return _dbContext.Perfis.ToList();
        }
    }
}
