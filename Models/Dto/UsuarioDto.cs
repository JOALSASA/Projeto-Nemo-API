namespace Projeto_Nemo.Models.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public String NomeUsuario { get; set; } = null!;
        public String Email { get; set; } = null!;

        public UsuarioDto(Usuario usuario)
        {
            Id = usuario.Id;
            NomeUsuario = usuario.NomeUsuario;
            Email = usuario.Email;
        }

        public UsuarioDto(UsuarioAquario usuarioAquario)
        {
            Id = usuarioAquario.Usuario.Id;
            NomeUsuario = usuarioAquario.Usuario.NomeUsuario;
            Email = usuarioAquario.Usuario.Email;
        }
    }
}
