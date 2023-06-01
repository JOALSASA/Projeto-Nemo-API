using Projeto_Nemo.Exceptions;
using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Repositories.Interfaces;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Services
{
    public class AquarioService: IAquarioService
    {
        
        private readonly IAquarioRepository _aquarioRepository;
        public AquarioService(IAquarioRepository aquarioRepository)
        {
            _aquarioRepository = aquarioRepository;
        }


        public List<AquarioDto> ListarAquarios(int idUsuario)
        {
            List<Aquario> aquariosUsuario = _aquarioRepository.RecuperarPorUsuarioId(idUsuario);
            if (aquariosUsuario.Count <= 0)
            {
                throw new NotFoundException("Usuário não possui aquários cadastrados.");
            }

            List<AquarioDto> aquariosUsuarioDto = aquariosUsuario.Select(aquario => new AquarioDto(aquario)).ToList();
            return aquariosUsuarioDto;
        }
        
    }
}
