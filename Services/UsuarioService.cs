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

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public UsuarioDto Inserir(NovoUsuarioForm novoUsuario)
        {
            Usuario usuario = new Usuario
            {
                NomeUsuario = novoUsuario.NomeUsuario,
                Senha = novoUsuario.Senha,
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

            List<Usuario> listaUsuarios = _usuarioRepository.FindUsuarioByNome(editarUsuario.NomeUsuario);

            // Verifica se o novo nome de usuario já está em uso
            if (listaUsuarios.Exists(usuarios => usuarios.NomeUsuario.Equals(editarUsuario.NomeUsuario)))
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

        public UsuarioDto FindUsuarioById(int id)
        {
            var usuario = _usuarioRepository.FindUsuarioById(id);
            if (usuario == null)
            {
                throw new NotFoundException("Usuário não encontrado.");
            }

            return new UsuarioDto(usuario);
        }

        public List<UsuarioDto> FindUsuarioByNome(string nome)
        {
            List<UsuarioDto> listaUsuarioDtos = new List<UsuarioDto>();
            List<Usuario> listaUsuarios = _usuarioRepository.FindUsuarioByNome(nome);
            foreach (var usuario in listaUsuarios)
            {
                listaUsuarioDtos.Add(new UsuarioDto(usuario));
            }

            return listaUsuarioDtos;
        }
    }
}