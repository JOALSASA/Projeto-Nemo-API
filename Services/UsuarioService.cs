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

        public UsuarioDto cadastrarNovoUsuario(NovoUsuarioForm novoUsuario)
        {
            Usuario usuario = new Usuario
            {
                NomeUsuario = novoUsuario.NomeUsuario,
                senha = novoUsuario.senha
            };

            return new UsuarioDto(_usuarioRepository.Inserir(usuario));
        }
    }
}
