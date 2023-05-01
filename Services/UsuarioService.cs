using Microsoft.IdentityModel.Tokens;
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

        public Usuario Excluir(Usuario usuario)
        {
            throw new NotImplementedException();
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

        public List<UsuarioDto> FindUsuarioByNome(string nome)
        {
            List<UsuarioDto> listaUsuarioDtos = new List<UsuarioDto>();
            List<Usuario> listaUsuarios = _usuarioRepository.FindUsuarioByNome(nome);
            foreach (var u in listaUsuarios)
            {
                listaUsuarioDtos.Add(UsuarioDto.CriarUsuarioDto(u));
            }
            return listaUsuarioDtos;
        }
    }
}
