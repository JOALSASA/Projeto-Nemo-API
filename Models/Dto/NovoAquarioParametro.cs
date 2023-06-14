using System.ComponentModel.DataAnnotations;

namespace Projeto_Nemo.Models.Dto
{
    public class NovoAquarioParametro
    {
        [Required(ErrorMessage = "Aquário é requerido.", AllowEmptyStrings = false)]
        public int AquariosId { get; set; }
        [Required(ErrorMessage = "Parametro é requerido.", AllowEmptyStrings = false)]
        public int ParametrosId { get; set; }
        [Required(ErrorMessage = "Valor é requerido.", AllowEmptyStrings = false)]
        public int Valor { get; set; }
    }
}
