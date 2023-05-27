namespace Projeto_Nemo.Models
{
    public class PerfilUsuario
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
        
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; } = null!;
    }
}
