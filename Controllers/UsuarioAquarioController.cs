using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class UsuarioAquarioController : ControllerBase
    {
        private readonly IUsuarioAquarioService _usuarioAquarioService;

        public UsuarioAquarioController (IUsuarioAquarioService usuarioAquarioService)
        {
            _usuarioAquarioService = usuarioAquarioService;
        }

        [HttpPost("aquario/{idAquario:int}/usuario/{idUsuario:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult PartilharAquarioComUsuario(int idAquario, int idUsuario)
        {
            _usuarioAquarioService.PartilharAquarioComUsuario(idAquario, idUsuario);
            return NoContent();
        }

        [HttpGet("aquario/{idAquario:int}/usuario/{idUsuario:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioAquarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UsuarioAquarioDto> BuscarPorId(int idAquario, int idUsuario)
        {
            return Ok( new UsuarioAquarioDto(_usuarioAquarioService.BuscarUsuarioAquarioPorIds(idAquario, idUsuario)));
        }
    }
}
