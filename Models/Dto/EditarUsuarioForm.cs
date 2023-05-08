using System.ComponentModel.DataAnnotations;

namespace Projeto_Nemo.Models.Dto
{
    public class EditarUsuarioForm
    {
        [Required(ErrorMessage = "Nome de usuário é requerido.", AllowEmptyStrings = false)]
        public String NomeUsuario { get; } = null!;
    }
}
