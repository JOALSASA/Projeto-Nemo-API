using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Models;

namespace Projeto_Nemo.Services.Interfaces
{
    public interface IAquarioService
    {
        Aquario Inserir(NovoAquarioForm novoAquario, Usuario usuario);
        Aquario RecuperarPorId(int id);
        List<AquarioDto> ListarAquarios(int idUsuario, string? nomeAquario);
    }
}
