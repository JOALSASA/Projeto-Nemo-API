using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_Nemo.Models;
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

        [HttpPost]
        public void CadastrarUsuario(NovoUsuarioForm usuarioForm) {

        }

        [HttpGet]
        public Usuario FindUsuarioNome(string nome)
        {
            Usuario usuario = _usuarioService.FindUsuarioByNome(nome);
            return usuario;
        }
        
        [HttpDelete]
        public IActionResult ExcluirUsuario(NovoUsuarioForm usuarioForm)
        {
            _usuarioService.Excluir(usuarioForm);
            return Ok("Usuário deletado com sucesso!");
        }
    }
}