using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Exceptions;
using Projeto_Nemo.Models;
using Projeto_Nemo.Repositories.Interfaces;
using Projeto_Nemo.Services.Interfaces;

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
    }
}