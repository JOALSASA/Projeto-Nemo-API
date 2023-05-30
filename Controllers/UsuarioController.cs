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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UsuarioDto> BuscarPorId(int id)
        {
            return Ok(new UsuarioDto(_usuarioService.RecuperarPorId(id)));
        }

        [HttpGet]
        [Route("consultar")]
        public IActionResult FindUsuarioNome(string nome)
        {
            List<UsuarioDto> usuarios = _usuarioService.RecuperarPorNome(nome)
                .Select(usu => new UsuarioDto(usu))
                .ToList();
            return Ok(usuarios);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarUsuario(int id)
        {
            _usuarioService.Excluir(id);
            return NoContent();
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsuarioDto))]
        public ActionResult<UsuarioDto> CadastrarUsuario([FromBody] NovoUsuarioForm usuarioForm)
        {
            UsuarioDto usuarioDto = new UsuarioDto(_usuarioService.Inserir(usuarioForm));
            return CreatedAtAction(nameof(BuscarPorId), new { id = usuarioDto.Id }, usuarioDto);
        }

        [HttpPost]
        [Route("autenticar")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioDto))]
        public ActionResult<UsuarioDto> Autenticar([FromBody] LoginForm loginForm)
        {
            return Ok(_usuarioService.Autenticar(loginForm));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<UsuarioDto> EditarUsuario(int id, [FromBody] EditarUsuarioForm editarUsuario)
        {
            UsuarioDto usuarioDto = new UsuarioDto(_usuarioService.Alterar(id, editarUsuario));
            return Ok(usuarioDto);
        }
    }
}