using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_Nemo.Models.Dto;

namespace Projeto_Nemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        
        [HttpPost]
        public void cadastrarUsuario(NovoUsuarioForm usuarioForm) {

        }

    }
}