using Microsoft.AspNetCore.Authorization;
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
        
        [HttpGet("{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UsuarioDto> BuscarPorId(int id)
        {
            var usuarioDto = _usuarioService.FindUsuarioById(id);
            return Ok(usuarioDto);
        }
        
        [HttpGet]
        [Authorize]
        [Route("consultar")]
        public IActionResult  FindUsuarioNome(string nome)
        {
            List<UsuarioDto> usuarios = _usuarioService.FindUsuarioByNome(nome);
            return Ok(usuarios);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsuarioDto))]
        public ActionResult<UsuarioDto> CadastrarUsuario([FromBody] NovoUsuarioForm usuarioForm)
        {
            UsuarioDto usuarioDto = _usuarioService.Inserir(usuarioForm);
            return CreatedAtAction(nameof(BuscarPorId),new {id = usuarioDto.Id}, usuarioDto);
        }
        
        [HttpPost]
        [Route("autenticar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioDto))]
        public ActionResult<UsuarioDto> Autenticar([FromBody] LoginForm loginForm)
        {
            return Ok(_usuarioService.Autenticar(loginForm));
        }
    }
}