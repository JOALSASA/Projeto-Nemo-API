using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Nemo.Models
{
    public class AquarioParametro
    {
        public int Id { get; set; }

        public int AquariosId { get; set; }
        public int ParametrosId { get; set; }

        public Aquario Aquario { get; set; } = null!;
        public Parametro Parametro { get; set; } = null!;
        public List<Historico> Historicos { get; set; } = new();

        public int Valor { get; set; }
    }
}
