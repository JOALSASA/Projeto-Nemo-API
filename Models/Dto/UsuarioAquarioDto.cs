namespace Projeto_Nemo.Models.Dto
{
    public class UsuarioAquarioDto
    {
        public int Id { get; set; }
        public AquarioDto aquarioDto { get; set; }
        public UsuarioDto usuarioDto { get; set; }

        public UsuarioAquarioDto(UsuarioAquario usuarioAquario) 
        {
            Id = usuarioAquario.Id;
            aquarioDto = new AquarioDto(usuarioAquario.Aquario);
            usuarioDto = new UsuarioDto(usuarioAquario.Usuario);
        }
    }
}
