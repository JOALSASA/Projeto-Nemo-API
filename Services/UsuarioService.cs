using System.Net;
using Projeto_Nemo.Exceptions;
using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Repositories.Interfaces;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsuarioService(IUsuarioRepository usuarioRepository, ITokenService tokenService,
            IHttpContextAccessor httpContextAccessor)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        public UsuarioDto Inserir(NovoUsuarioForm novoUsuario)
        {
            Usuario usuario = new Usuario
            {
                NomeUsuario = novoUsuario.NomeUsuario,
                Senha = BCrypt.Net.BCrypt.HashPassword(novoUsuario.Senha),
                Email = novoUsuario.Email
            };

            return new UsuarioDto(_usuarioRepository.Inserir(usuario));
        }

        public UsuarioDto Alterar(int id, EditarUsuarioForm editarUsuario)
        {
            var usuarioExistente = _usuarioRepository.FindUsuarioById(id);

            if (usuarioExistente == null)
            {
                throw new NotFoundException("Usuário não encontrado.");
            }


            // Verifica se o novo nome de usuario já está em uso
            if (_usuarioRepository.FindUsuarioByName(editarUsuario.NomeUsuario) != null)
            {
                throw new ConflictException("Este nome de usuário já está em uso.");
            }

            usuarioExistente.NomeUsuario = editarUsuario.NomeUsuario;

            return new UsuarioDto(_usuarioRepository.Alterar(usuarioExistente));
        }

        public Usuario Excluir(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario RecuperarPorId(int id)
        {
            var usuario = _usuarioRepository.FindUsuarioById(id);
            if (usuario == null)
            {
                throw new NotFoundException("Usuário não encontrado.");
            }

            return usuario;
        }

        public List<UsuarioDto> RecuperarPorNome(string nome)
        {
            List<UsuarioDto> listaUsuarioDtos = new List<UsuarioDto>();
            List<Usuario> listaUsuarios = _usuarioRepository.FindUsuarioByNome(nome);
            foreach (var usuario in listaUsuarios)
            {
                listaUsuarioDtos.Add(new UsuarioDto(usuario));
            }

            return listaUsuarioDtos;
        }

        public string Autenticar(LoginForm loginForm)
        {
            Usuario? usuario = _usuarioRepository.RecuperarPorEmail(loginForm.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginForm.Senha, usuario.Senha))
                throw new AppException("Usuário ou senha incorretos.", HttpStatusCode.Unauthorized);

            return _tokenService.GerarToken(usuario);
        }
    }
}