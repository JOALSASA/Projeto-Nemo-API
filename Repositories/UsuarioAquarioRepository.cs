﻿using Microsoft.EntityFrameworkCore;
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
        }

        public UsuarioAquario? BuscarUsuarioAquarioPorIds(int idAquario, int idUsuario)
        {
            return _dbContext.UsuarioAquarios
                .Include(ua => ua.Aquario)
                .Include(ua => ua.Usuario)
                .FirstOrDefault(ua => ua.AquariosId == idAquario && ua.UsuariosId == idUsuario);
        }

        public UsuarioAquario? BuscarUsuarioAquarioPorId(int idUsuarioAquario)
        {
            return _dbContext.UsuarioAquarios
                .Include(ua => ua.Aquario)
                .Include(ua => ua.Usuario)
                .FirstOrDefault();
        }

        public List<UsuarioAquario> BuscarTodosUsuariosPermissao(int idAquario)
        {
            return _dbContext.UsuarioAquarios
                .Include(ua => ua.Usuario)
                .Where(ua => ua.AquariosId == idAquario)
                .ToList();
        }

        public void ExcluirUsuarioAutorizado(UsuarioAquario usuarioAquario)
        {
            _dbContext.UsuarioAquarios.Remove(usuarioAquario);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}