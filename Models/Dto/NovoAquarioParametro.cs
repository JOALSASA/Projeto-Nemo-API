using Projeto_Nemo.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Nemo.Models.Dto
{
    public class NovoAquarioParametro
    {
        [Required(ErrorMessage = "Aquário é requerido.", AllowEmptyStrings = false)]
        public int AquariosId { get; set; }
        [Required(ErrorMessage = "Parametro é requerido.", AllowEmptyStrings = false)]
        public TipoParametro TipoParametro { get; set; }
        [Required(ErrorMessage = "Valor é requerido.", AllowEmptyStrings = false)]
        public int Valor { get; set; }
    }
}
