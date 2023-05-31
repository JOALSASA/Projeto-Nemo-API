using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Services.Interfaces;
using System.Security.Claims;

namespace Projeto_Nemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AquarioController : ControllerBase
    {
        private readonly IAquarioService _aquarioService;

        public AquarioController(IAquarioService aquarioService)
        {
            _aquarioService = aquarioService;
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AquarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AquarioDto> BuscarPorId(int id)
        {
            return Ok(new AquarioDto(_aquarioService.RecuperarPorId(id)));
        }
    }
}