using Microsoft.EntityFrameworkCore;
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

            //Uma lista com os aquarios do usuario logado
            var aquariosProprietario = _dbContext.Aquarios.Where(u => u.Usuario.Id == id).ToList();

            //Uma lista com os aquarios que o usuario logado tem permissao
            var aquariosComPermissao = _dbContext.UsuarioAquarios
                .Where(u => u.UsuariosId == id)
                .Include(u => u.Usuario)
                .Select(u => u.Aquario)
                .ToList();

            //Juncao das duas listas
            var aquarios = aquariosProprietario.Concat(aquariosComPermissao).ToList();

            if (nomeAquario != null)
            {
                return aquarios.Where(u => u.Usuario.Id == id & u.Nome.Contains(nomeAquario)).ToList();
            }

            return aquarios;


            /*
            if (nomeAquario != null)
            {
                return _dbContext.Aquarios.Where(u => u.Usuario.Id == id & u.Nome.Contains(nomeAquario)).ToList();
            }
            return _dbContext.Aquarios.Where(u => u.Usuario.Id == id).ToList();
            */
        }

        public Aquario Inserir(Aquario aquario)
        {
            _dbContext.Add(aquario);
            _dbContext.SaveChanges();

            return aquario;
        }
    }
}
