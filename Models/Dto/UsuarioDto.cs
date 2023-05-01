namespace Projeto_Nemo.Models.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public String NomeUsuario { get; set; } = null!;

        public UsuarioDto(Usuario usuario)
        {
            Id = usuario.Id;
            NomeUsuario = usuario.NomeUsuario;
        }

    }
}
