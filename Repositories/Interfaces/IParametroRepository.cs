using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Enums;

namespace Projeto_Nemo.Repositories.Interfaces
{
    public interface IParametroRepository
    {
        Parametro? BuscarParametroPorTipo(TipoParametro tipoParametro);
        Parametro? BuscarParametroPorId(int idParametro);
        void AdicionarParametroAoAquario(AquarioParametro aquarioParametro);
        void ExcluirParametroDoAquario(AquarioParametro aquarioParametro);
        AquarioParametro? BuscarAquarioParametro(int idAquarioParametro);
        List<AquarioParametro> ParametrosDoAquario(int idAquario);
        void AtualizarParametro(AquarioParametro aquarioParametro);
        void SaveChanges();
    }
}