namespace Projeto_Nemo.Models.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public String NomeUsuario { get; set; } = null!;

        public List<Aquario> ListaAquarios { get; set; } = new();
        public List<Historico> ListaHistoricos { get; set; } = new();
        public List<UsuarioAquario> UsuarioAquarios { get; set; } = new();

        public UsuarioDto(Usuario usuario)
        {
            Id = usuario.Id;
            NomeUsuario = usuario.NomeUsuario;
            ListaAquarios = usuario.ListaAquarios;
            ListaHistoricos = usuario.ListaHistoricos;
            UsuarioAquarios = usuario.UsuarioAquarios;
        }
    }
}
