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

        public UsuarioService(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
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
        
        public Usuario Alterar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            var usuario = _usuarioRepository.FindUsuarioById(id);
            if (usuario == null)
            {
                throw new NotFoundException("Usuário não encontrado.");
            }
            _usuarioRepository.Excluir(usuario);
        }

        public UsuarioDto RecuperarPorId(int id)
        {
            var usuario = _usuarioRepository.FindUsuarioById(id);
            if (usuario == null)
            {
                throw new NotFoundException("Usuário não encontrado.");
            }

            return new UsuarioDto(usuario);
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

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginForm.Senha,usuario.Senha))
                throw new AppException("Usuário ou senha incorretos.", HttpStatusCode.Unauthorized);

            return _tokenService.GerarToken(usuario);
        }
    }
}