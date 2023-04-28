namespace NEMO.Models
{
    public class Historico
    {
        public int Id { get; set; }
        public int Valor { get; set; }
        public DateTime Hora { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public AquarioParametro AquarioParametro { get; set;} = null!;
    }
}
