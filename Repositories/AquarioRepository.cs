﻿using Microsoft.EntityFrameworkCore;
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
                return _dbContext.Aquarios.Where(u => u.Usuario.Id == id & u.Nome.Contains(nomeAquario)).ToList();
            }
            return _dbContext.Aquarios.Where(u => u.Usuario.Id == id).ToList();
        }

        public Aquario Inserir(Aquario aquario)
        {
            _dbContext.Add(aquario);
            _dbContext.SaveChanges();

            return aquario;
        }


    }
}
