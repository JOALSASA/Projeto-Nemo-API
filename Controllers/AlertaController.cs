using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AlertaController : ControllerBase
    {
        private readonly IAlertaService _alertaService;

        public AlertaController(IAlertaService alertaService)
        {
            _alertaService = alertaService;
        }

        [HttpPost]
        [Route("AdicionarAlerta")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AdicionarAlerta([FromBody] NovoAlertaForm novoAlertaForm)
        {
            _alertaService.AdicionarAlerta(novoAlertaForm);
            return Ok();
        }
        
        [HttpGet]
        [Route("ConsultarAlertas/{idAquario:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ConsultarAlertasDoAquario(int idAquario)
        {
            return Ok(_alertaService.ConsultarAlertasDoAquario(idAquario).Select(a => new AlertaDto(a)).ToList());
        }
        
        [HttpPut]
        [Route("AlterarAlerta/{idAlerta:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AlterarAlerta(int idAlerta, [FromBody] NovoAlertaForm novoAlertaForm)
        {
            _alertaService.AlterarAlerta(idAlerta, novoAlertaForm);
            return Ok();
        }
        
        [HttpDelete]
        [Route("ExcluirAlerta/{idAlerta:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarParametroDoAquario(int idAlerta)
        {
            _alertaService.ExcluirAlertaDoAquario(idAlerta);
            return NoContent();
        }
        
    }
}

