namespace Projeto_Nemo.Models
{
    public class Aquario
    {
        public int Id { get; set; }
        public String NomeAquario { get; set; } = null!;
        public int Largura { get; set; }
        public int Altura { get; set; }
        public int Comprimento { get; set; }

        public Usuario Usuario { get; set;} = null!;
        public List<AquarioParametro> AquarioParametros { get; set; } = new();
        public List<UsuarioAquario> UsuarioAquarios { get; set; } = new();
    }
}
