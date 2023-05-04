using System.ComponentModel.DataAnnotations;
namespace Projeto_Nemo.Models.Dto
{
    public class NovoUsuarioForm
    {
        [Required(ErrorMessage = "Nome de usu�rio � requerido.", AllowEmptyStrings = false)]
        public String NomeUsuario { get; set; } = null!;
        [Required(ErrorMessage = "Senha requerida", AllowEmptyStrings = false)]
        public String senha { get; set; } = null!;
    }
}