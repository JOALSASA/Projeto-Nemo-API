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

        public AquarioParametroService (IAquarioParametroRepository aquarioParametroRepository)
        {
            _aquarioParametroRepository = aquarioParametroRepository;
        }

        public void AdicionarParametroAoAquario(NovoAquarioParametro novoAquarioParametro)
        {

            var parametro = _aquarioParametroRepository.BuscarParametroPorTipo(novoAquarioParametro.TipoParametro);

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
