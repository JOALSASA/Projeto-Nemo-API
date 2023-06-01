using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;

namespace Projeto_Nemo.Services.Interfaces
{
    public interface IAquarioService
    {

        List<AquarioDto> ListarAquarios(int idUsuario);
    }
}
