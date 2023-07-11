using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Models.Enums;

namespace Projeto_Nemo.Services.Interfaces
{
    public interface IParametroService
    {
        void AdicionarParametroAoAquario(NovoAquarioParametro novoAquarioParametro);
        void ExcluirParametroDoAquario(int idAquario, int idAquarioParametro);
        List<AquarioParametro> ParametrosDoAquario(int idAquario);
    }
}
