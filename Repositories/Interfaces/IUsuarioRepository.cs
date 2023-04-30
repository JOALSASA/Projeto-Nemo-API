using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Nemo.Models;

namespace Projeto_Nemo.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Inserir(Usuario usuario);
        Task<Usuario> Alterar(Usuario usuario);
        Task<Usuario> Excluir(Usuario usuario);
        Task<Usuario> FindUsuarioById(int id);
    }
}