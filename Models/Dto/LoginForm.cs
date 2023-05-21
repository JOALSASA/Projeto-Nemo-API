using System.ComponentModel.DataAnnotations;

namespace Projeto_Nemo.Models.Dto;

public class LoginForm
{
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Senha { get; set; } = null!;
}