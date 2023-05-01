using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Repositories.Interfaces;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _usuarioRepository = repository;
        }

        public UsuarioDto FindUsuarioById(int id)
        {
            var usuario = _usuarioRepository.FindUsuarioById(id);

            if (usuario != null)
            {
                return new UsuarioDto(usuario);
            }

            return null;
        }

    }
}
