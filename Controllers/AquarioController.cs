using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AquarioController : ControllerBase
    {
        private readonly IAquarioService _aquarioService;
        private readonly IUsuarioService _usuarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AquarioController(IAquarioService aquarioService, IHttpContextAccessor httpContextAccessor,
            IUsuarioService usuarioService)
        {
            _aquarioService = aquarioService;
            _httpContextAccessor = httpContextAccessor;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AquarioDto))]
        public ActionResult<AquarioDto> CadastrarAquario([FromBody] NovoAquarioForm aquarioForm)
        {
            Usuario? usuarioLogado = _httpContextAccessor.HttpContext.Items["User"] as Usuario;

            AquarioDto aquarioDto = new AquarioDto(_aquarioService.Inserir(aquarioForm, usuarioLogado));

            return CreatedAtAction(nameof(BuscarPorId), new { id = aquarioDto.Id }, aquarioDto);
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AquarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AquarioDto> BuscarPorId(int id)
        {
            return Ok(new AquarioDto(_aquarioService.RecuperarPorId(id)));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AquarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AquarioDto> EditarAquario(int id, [FromBody] EditarAquarioForm editarAquario)
        {
            AquarioDto aquarioDto = new AquarioDto(_aquarioService.Alterar(id, editarAquario));
            return Ok(aquarioDto);
        }

        [HttpGet]
        [Route("listar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AquarioDto))]
        public ActionResult<List<AquarioDto>> ListarAquarios([FromQuery] string? nomeAquario)
        {
            Usuario usuarioLogado = _usuarioService.RecuperarUsuarioAutenticado();
            List<Aquario> aquariosUsuario = _aquarioService.ListarAquarios(usuarioLogado.Id, nomeAquario);
            return Ok(aquariosUsuario.Select(aquario => new AquarioDto(aquario)).ToList());
        }

        [HttpPost]
        [Route("parametro")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CadastrarParametro([FromBody] NovoAquarioParametro novoAquarioParametro)
        {
            _aquarioService.CadastrarParametro(novoAquarioParametro);
            return Ok();
        }
    }
}