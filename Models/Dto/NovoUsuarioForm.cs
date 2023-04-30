using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Nemo.Models.Dto
{
    public class NovoUsuarioForm
    {
        public String NomeUsuario { get; set; } = null!;
        public String senha { get; set; } = null!;
    }
}