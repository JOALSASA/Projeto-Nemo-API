namespace Projeto_Nemo.Models
{
    public class UsuarioAquario
    {
        public int Id { get; set; }

        public int UsuariosId { get; set; }
        public int AquariosId { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public Aquario Aquario { get; set; } = null!;
    }
}
