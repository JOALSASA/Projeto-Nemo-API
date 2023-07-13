using Microsoft.EntityFrameworkCore;
using Projeto_Nemo.Data;
using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;
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

        public Aquario Alterar(Aquario aquario)
        {
            _dbContext.Update(aquario);
            _dbContext.SaveChanges();
            return aquario;
        }

        public void Excluir(Aquario aquario)
        {
            _dbContext.Aquarios.Remove(aquario);
            _dbContext.SaveChanges();
        }

        public Aquario? RecuperarPorId(int id)
        {
            return _dbContext.Aquarios.Where(a => a.Id.Equals(id)).FirstOrDefault();
        }

        public List<Aquario> RecuperarPorUsuarioId(int id, string? nomeAquario)
        {

            if (nomeAquario != null) 
            {
                return _dbContext.Aquarios
                    .Include(a => a.UsuarioAquarios
                        .Where(ua => ua.UsuariosId == id))
                    .Include(a => a.Usuario)
                        .Where(a => a.Usuario.Id == id && a.Nome.Contains(nomeAquario))
                    .ToList();

            }

            return _dbContext.Aquarios
                    .Include(a => a.Usuario)
                    .Include(a => a.UsuarioAquarios)
                        .Where(a => a.Usuario.Id == id || a.UsuarioAquarios.Any(ua => ua.UsuariosId == id))
                    .ToList();
        }

        public Aquario Inserir(Aquario aquario)
        {
            _dbContext.Add(aquario);
            _dbContext.SaveChanges();

            return aquario;
        }
    }
}
