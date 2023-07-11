using Projeto_Nemo.Exceptions;
using Projeto_Nemo.Models;
using Projeto_Nemo.Repositories;
using Projeto_Nemo.Repositories.Interfaces;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Services
{
    public class UsuarioAquarioService : IUsuarioAquarioService
    {
        private readonly IUsuarioAquarioRepository _usuarioAquarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IAquarioService _aquarioService;

        public UsuarioAquarioService (IUsuarioAquarioRepository usuarioAquarioRepository, IUsuarioService usuarioService, IAquarioService aquarioService)
        {
            _usuarioAquarioRepository = usuarioAquarioRepository;
            _usuarioService = usuarioService;
            _aquarioService = aquarioService;
        }

        public void PartilharAquarioComUsuario(int idAquario, int idUsuario)
        {
            var usuario = _usuarioService.RecuperarPorId(idUsuario);
            var aquario = _aquarioService.RecuperarPorId(idAquario);
            var usuarioAquarioExistente = _usuarioAquarioRepository.BuscarUsuarioAquarioPorIds(idAquario, idUsuario);

            if (usuarioAquarioExistente !=  null)
            {
                throw new ConflictException("O usuário já possui permissão para este aquário.");
            }

            UsuarioAquario usuarioAquario = new UsuarioAquario
            {
                Usuario = usuario,
                Aquario = aquario
            };

            _usuarioAquarioRepository.PartilharAquarioComUsuario(usuarioAquario);
        }

        public UsuarioAquario BuscarUsuarioAquarioPorIds(int idAquario, int idUsuario)
        {

            var usuarioAquario = _usuarioAquarioRepository.BuscarUsuarioAquarioPorIds(idAquario, idUsuario);

            if (usuarioAquario == null)
            {
                throw new NotFoundException("Usuário/Aquário não encontrado.");
            }

            return usuarioAquario;
        }
    }
}
