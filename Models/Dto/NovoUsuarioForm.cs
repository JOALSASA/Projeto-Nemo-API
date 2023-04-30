using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Nemo.Models.Dto
{
    public class NovoUsuarioForm
    {
        [Required(ErrorMessage = "Nome de usuário é requerido.", AllowEmptyStrings = false)]
        public String NomeUsuario { get; set; } = null!;
        [Required(ErrorMessage = "Senha requerida", AllowEmptyStrings = false)]
        public String senha { get; set; } = null!;
    }
}