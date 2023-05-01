using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Repositories.Interfaces;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Inserir(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Alterar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Excluir(NovoUsuarioForm usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Excluir(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario FindUsuarioById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario FindUsuarioByNome(string nome)
        {
            Task<Usuario> usu = _usuarioRepository.FindUsuarioByNome(nome);
            if (usu == null)
            {
                throw new Exception("Usuário não encontrado!");
            }
            return usu.Result;
        }
    }
}
