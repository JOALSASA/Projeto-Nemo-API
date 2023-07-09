using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Enums;

namespace Projeto_Nemo.Repositories.Interfaces
{
    public interface IParametroRepository
    {
        Parametro? BuscarParametroPorTipo(TipoParametro tipoParametro);
        void AdicionarParametroAoAquario(AquarioParametro aquarioParametro);
        void ExcluirParametroDoAquario(AquarioParametro aquarioParametro);
        AquarioParametro? BuscarAquarioParametro(int idAquario, int idParametro);
    }
}