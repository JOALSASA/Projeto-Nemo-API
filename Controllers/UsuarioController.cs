using Microsoft.AspNetCore.Mvc;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public void cadastrarUsuario(NovoUsuarioForm usuarioForm) {

        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UsuarioDto> buscarPorId(int id)
        {
            var usuarioDto = _usuarioService.FindUsuarioById(id);

            return usuarioDto == null ? NotFound() : Ok(usuarioDto);
        }
        
    }
}