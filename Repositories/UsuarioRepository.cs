using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public bool Excluir(Usuario usuario)
        {
            _dbContext.Usuarios.Remove(usuario);
            _dbContext.SaveChangesAsync();
            return true;
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