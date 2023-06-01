using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Dto;
using Projeto_Nemo.Services.Interfaces;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AquarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarAquarios(int id, string? nomeAquario)
        {
            return Ok(_aquarioService.ListarAquarios(id, nomeAquario));
        }
    }
}