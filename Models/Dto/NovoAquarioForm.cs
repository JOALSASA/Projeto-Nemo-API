using System.ComponentModel.DataAnnotations;

namespace Projeto_Nemo.Models.Dto
{
    public class NovoAquarioForm
    {
        [Required(ErrorMessage = "Nome do aquário é requerido.", AllowEmptyStrings = false)]
        public String Nome { get; set; } = null!;
        [Required(ErrorMessage = "Largura do aquário é requerida.", AllowEmptyStrings = false)]
        public int Largura { get; set; }
        [Required(ErrorMessage = "Altura do aquário é requerida.", AllowEmptyStrings = false)]
        public int Altura { get; set; }
        [Required(ErrorMessage = "Comprimento do aquário é requerido.", AllowEmptyStrings = false)]
        public int Comprimento { get; set; }
    }
}
