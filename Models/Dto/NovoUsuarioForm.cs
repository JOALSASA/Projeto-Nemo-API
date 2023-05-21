using System.ComponentModel.DataAnnotations;
namespace Projeto_Nemo.Models.Dto
{
    public class NovoUsuarioForm
    {
        [Required(ErrorMessage = "Nome de usuário é requerido.", AllowEmptyStrings = false)]
        public String NomeUsuario { get; set; } = null!;
        [EmailAddress]
        [Required(ErrorMessage = "Email é requerido.", AllowEmptyStrings = false)]
        public String Email { get; set; } = null!;
        [Required(ErrorMessage = "Senha requerida", AllowEmptyStrings = false)]
        public String Senha { get; set; } = null!;
    }
}