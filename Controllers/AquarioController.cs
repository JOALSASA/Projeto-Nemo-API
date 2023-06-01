using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Services;
using Projeto_Nemo.Services.Interfaces;
using System.Security.Claims;

namespace Projeto_Nemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AquarioController : ControllerBase
    {
        private readonly IAquarioService _aquarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AquarioController(IAquarioService aquarioService, IHttpContextAccessor httpContextAccessor)
        {
            _aquarioService = aquarioService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AquarioDto))]
        public ActionResult<AquarioDto> CadastrarAquario([FromBody] NovoAquarioForm aquarioForm)
        {
            Usuario usuarioLogado = _httpContextAccessor.HttpContext.Items["User"] as Usuario;

            AquarioDto aquarioDto = new AquarioDto(_aquarioService.Inserir(aquarioForm, usuarioLogado));

            return CreatedAtAction(nameof(BuscarPorId), new { id = aquarioDto.Id }, aquarioDto);
        }
    }
}