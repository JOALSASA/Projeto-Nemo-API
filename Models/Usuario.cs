namespace Projeto_Nemo.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String NomeUsuario { get; set; } = null!;
        public String Senha { get; set; } = null!;

        public List<Aquario> ListaAquarios { get; set; } = new();
        public List<Historico> ListaHistoricos { get; set; } = new();
        public List<UsuarioAquario> UsuarioAquarios { get; set; } = new();
    }
}
