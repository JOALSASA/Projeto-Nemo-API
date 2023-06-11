
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Exceptions;
using Projeto_Nemo.Models;
using Projeto_Nemo.Repositories.Interfaces;
using Projeto_Nemo.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Projeto_Nemo.Services
{
    public class AquarioService : IAquarioService
    {
        private readonly IAquarioRepository _aquarioRepository;
        
        public AquarioService(IAquarioRepository aquarioRepository)
        {
            _aquarioRepository = aquarioRepository;
        }
        
        public Aquario Inserir(NovoAquarioForm novoAquario, Usuario usuario)
        {
            Aquario aquario = new Aquario
            {
                Nome = novoAquario.Nome,
                Largura = novoAquario.Largura,
                Altura = novoAquario.Altura,
                Comprimento = novoAquario.Comprimento,
                Usuario = usuario
            };

            return _aquarioRepository.Inserir(aquario);
        }

        public Aquario RecuperarPorId(int id)
        {
            var aquario = _aquarioRepository.RecuperarPorId(id);
            if (aquario == null)
            {
                throw new NotFoundException("Aquário não encontrado.");
            }

            return aquario;
        }

        public Aquario Alterar(int id, EditarAquarioForm editarAquario)
        {

            Aquario? aquarioExistente = _aquarioRepository.RecuperarPorId(id);

            if (aquarioExistente == null)
            {
                throw new NotFoundException("Aquário não encontrado.");
            }

            if (!editarAquario.Nome.IsNullOrEmpty())
            {
                aquarioExistente.Nome = editarAquario.Nome;
            }
            if (!editarAquario.Largura.Equals(0))
            {
                aquarioExistente.Largura = editarAquario.Largura;
            }
            if (!editarAquario.Altura.Equals(0))
            {
                aquarioExistente.Altura = editarAquario.Altura;
            }
            if (!editarAquario.Comprimento.Equals(0))
            {
                aquarioExistente.Comprimento = editarAquario.Comprimento;
            }

            return _aquarioRepository.Alterar(aquarioExistente);
        }

        public List<Aquario> ListarAquarios(int idUsuario, string? nomeAquario)
        {
            return _aquarioRepository.RecuperarPorUsuarioId(idUsuario, nomeAquario);
        }

        public void ExcluirAquario(Usuario usuario ,int idAquario)
        {
            var aquario = _aquarioRepository.RecuperarPorId(idAquario);
            if (aquario == null || aquario.Usuario.Id != usuario.Id)
            {
                throw new NotFoundException("Aquário não encontrado.");
            }
            _aquarioRepository.Excluir(aquario);
        }
    }
}