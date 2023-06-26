using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ParametroController : ControllerBase
    {
        private readonly IParametroService _parametroService;

        public ParametroController(IParametroService parametroService)
        {
            _parametroService = parametroService;
        }

        [HttpPost]
        [Route("AquarioParametro")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AdicionarParametroAoAquario([FromBody] NovoAquarioParametro novoAquarioParametro)
        {
            _parametroService.AdicionarParametroAoAquario(novoAquarioParametro);
            return Ok();
        }

        [HttpDelete("AquarioParaemtro/{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarParametroDoAquario(int id)
        {
            _parametroService.ExcluirParametroDoAquario(id);
            return NoContent();
        }
    }
}
