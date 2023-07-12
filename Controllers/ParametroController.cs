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
    public class ParametroController : ControllerBase
    {
        private readonly IParametroService _parametroService;

        public ParametroController(IParametroService parametroService)
        {
            _parametroService = parametroService;
        }

        [HttpPost]
        [Route("aquario-parametro")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AdicionarParametroAoAquario([FromBody] NovoAquarioParametro novoAquarioParametro)
        {
            _parametroService.AdicionarParametroAoAquario(novoAquarioParametro);
            return Ok();
        }

        [HttpDelete("aquario/{idAquario:int}/parametro/{idParametro:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarParametroDoAquario(int idAquario, int idParametro)
        {
            _parametroService.ExcluirParametroDoAquario(idAquario, idParametro);
            return NoContent();
        }

        [HttpGet("aquario/{idAquario:int}/parametro/todos")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ParametrosDoAquario(int idAquario)
        {
            List<AquarioParametro> aquarioParametros = _parametroService.ParametrosDoAquario(idAquario);
            
            List<AquarioParametroDto> aquarioParametroDtos = aquarioParametros
                .Select(ap => new AquarioParametroDto(ap))
                .ToList();
            
            return Ok(aquarioParametroDtos);
        }

        [HttpPut("aquario-parametro/{idAquarioParametro:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AtualizarValorAquarioParametro(int idAquarioParametro, int valor)
        {
            _parametroService.AtualizarValorAquarioParametro(idAquarioParametro, valor);
            return NoContent();
        }
        
        [HttpGet("aquario-parametro/{idAquarioParametro:int}/historico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarHistoricoAquarioParametro(int idAquarioParametro)
        {
            List<Historico> historicos = _parametroService.BuscarHistoricoAquarioParametro(idAquarioParametro);
            List<HistoricoDto> historicoDtos = historicos.Select(historico => new HistoricoDto(historico)).ToList();
            return Ok(historicoDtos);
        }
    }
}