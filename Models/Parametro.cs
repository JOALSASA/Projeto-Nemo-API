namespace NEMO.Models
{
    public class Parametro
    {
        public int Id { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public List<AquarioParametro> AquarioParametros { get; set; } = new();
    }
}
