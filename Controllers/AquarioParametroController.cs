using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AquarioParametroController : ControllerBase
    {
        private readonly IAquarioParametroService _aquarioParametroService;

        public AquarioParametroController(IAquarioParametroService aquarioParametroService)
        {
            _aquarioParametroService = aquarioParametroService;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AdicionarParametroAoAquario([FromBody] NovoAquarioParametro novoAquarioParametro)
        {
            _aquarioParametroService.AdicionarParametroAoAquario(novoAquarioParametro);
            return Ok();
        }
    }
}
