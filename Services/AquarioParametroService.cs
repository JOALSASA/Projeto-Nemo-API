using Projeto_Nemo.Exceptions;
using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Models.Enums;
using Projeto_Nemo.Repositories;
using Projeto_Nemo.Repositories.Interfaces;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Services
{
    public class AquarioParametroService : IAquarioParametroService
    {
        private readonly IAquarioParametroRepository _aquarioParametroRepository;
        private readonly IAquarioRepository _aquarioRepository;

        public AquarioParametroService (IAquarioParametroRepository aquarioParametroRepository, IAquarioRepository aquarioRepository)
        {
            _aquarioParametroRepository = aquarioParametroRepository;
            _aquarioRepository = aquarioRepository;
        }

        public void AdicionarParametroAoAquario(NovoAquarioParametro novoAquarioParametro)
        {

            var parametro = _aquarioParametroRepository.BuscarParametroPorTipo(novoAquarioParametro.TipoParametro);
            var aquario = _aquarioRepository.RecuperarPorId(novoAquarioParametro.AquariosId);

            if (parametro == null )
            {
                throw new NotFoundException("Parâmetro não encontrado.");
            }

            if (aquario == null)
            {
                throw new NotFoundException("Aquário não encontrado.");
            }

            AquarioParametro aquarioParametro = new AquarioParametro
            {
                AquariosId = novoAquarioParametro.AquariosId,
                Valor = novoAquarioParametro.Valor,
                ParametrosId = parametro.Id
            };

            _aquarioParametroRepository.AdicionarParametroAoAquario(aquarioParametro);
        }
    }
}
