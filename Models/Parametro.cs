using Projeto_Nemo.Models.Enums;

namespace Projeto_Nemo.Models
{
    public class Parametro
    {
        public int Id { get; set; }
        public TipoParametro Tipo { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public List<AquarioParametro> AquarioParametros { get; set; } = new();
    }
}
