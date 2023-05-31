namespace Projeto_Nemo.Models.Dto
{
    public class AquarioDto
    {
        public int Id { get; set; }
        public String Nome { get; set; } = null!;
        public int Largura { get; set; }
        public int Altura { get; set; }
        public int Comprimento { get; set; }

        public AquarioDto(Aquario aquario)
        {
            Id = aquario.Id;
            Nome = aquario.Nome;
            Largura = aquario.Largura;
            Altura = aquario.Altura;
            Comprimento = aquario.Comprimento;
        }
    }
}
