using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Enums;

namespace Projeto_Nemo.Repositories.Interfaces
{
    public interface IAquarioParametroRepository
    {
        Parametro? BuscarParametroPorTipo(TipoParametro tipoParametro);
        void AdicionarParametroAoAquario(AquarioParametro aquarioParametro);
    }
}
