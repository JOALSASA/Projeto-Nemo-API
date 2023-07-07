using Projeto_Nemo.Exceptions;
using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Models.Enums;
using Projeto_Nemo.Repositories.Interfaces;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Services
{
    public class ParametroService : IParametroService
    {
        private readonly IParametroRepository _parametroRepository;
        private readonly IAquarioRepository _aquarioRepository;

        public ParametroService(IParametroRepository parametroRepository, IAquarioRepository aquarioRepository)
        {
            _parametroRepository = parametroRepository;
            _aquarioRepository = aquarioRepository;
        }

        public void AdicionarParametroAoAquario(NovoAquarioParametro novoAquarioParametro)
        {

            var parametro = _parametroRepository.BuscarParametroPorTipo(novoAquarioParametro.TipoParametro);
            var aquario = _aquarioRepository.RecuperarPorId(novoAquarioParametro.IdAquario);

            if (parametro == null)
            {
                throw new NotFoundException("Parâmetro não encontrado.");
            }

            if (aquario == null)
            {
                throw new NotFoundException("Aquário não encontrado.");
            }

            AquarioParametro aquarioParametro = new AquarioParametro
            {
                AquariosId = novoAquarioParametro.IdAquario,
                Valor = novoAquarioParametro.Valor,
                ParametrosId = parametro.Id
            };

            _parametroRepository.AdicionarParametroAoAquario(aquarioParametro);
        }

        public void ExcluirParametroDoAquario(int idAquario, int idParametro)
        {
            var aquarioParametro = _parametroRepository.BuscarAquarioParametro(idAquario, idParametro);

            if (aquarioParametro == null)
            {
                throw new NotFoundException("Parâmetro não encontrado no aquário.");
            }

            _parametroRepository.ExcluirParametroDoAquario(aquarioParametro);
        }
    }
}