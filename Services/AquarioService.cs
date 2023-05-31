using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Models;
using Projeto_Nemo.Repositories.Interfaces;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Services
{
    public class AquarioService: IAquarioService
    {
        private readonly IAquarioRepository _aquarioRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public AquarioService(IAquarioRepository aquarioRepository, IUsuarioRepository usuarioRepository)
        {
            _aquarioRepository = aquarioRepository;
            _usuarioRepository = usuarioRepository;
        }

        public Aquario Inserir(NovoAquarioForm novoAquario, int idUsuarioAutenticado)
        {
            Usuario usuario = _usuarioRepository.FindUsuarioById(idUsuarioAutenticado);

            Aquario aquario = new Aquario
            {
                Nome = novoAquario.Nome,
                Largura = novoAquario.Largura,
                Altura = novoAquario.Altura,
                Comprimento = novoAquario.Comprimento,
                Usuario = usuario
            };

            return _aquarioRepository.Inserir(aquario);
        }
    }
}
