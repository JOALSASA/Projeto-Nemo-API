namespace Projeto_Nemo.Models;

public class Perfil
{
    public int Id { get; set; }
    public String Nome { get; set; } = null!;

    public List<Usuario> Usuarios { get; set; } = new();
}