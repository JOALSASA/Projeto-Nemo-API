using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Models.Enums;

namespace Projeto_Nemo.Services.Interfaces
{
    public interface IAquarioParametroService
    {
        void AdicionarParametroAoAquario(NovoAquarioParametro novoAquarioParametro);
    }
}
