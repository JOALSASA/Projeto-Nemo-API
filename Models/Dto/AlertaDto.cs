using System.Text.Json.Serialization;
using Projeto_Nemo.Models.Enums;

namespace Projeto_Nemo.Models.Dto
{
    public class AlertaDto
    {
        public int Id { get; set; }
        public String Nome { get; set; } = null!;
        public int Min { get; set; }
        public int Max { get; set; }
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EstadoAlerta EstadoAlerta { get; set; }
        
        public String NomeAquario { get; set; }
        
        public String TipoParametro { get; set; }
        
        public AlertaDto(Alerta alerta)
        {
            Id = alerta.Id;
            Nome = alerta.Nome;
            Min = alerta.Min;
            Max = alerta.Max;
            NomeAquario = alerta.Aquario.Nome;
            TipoParametro = alerta.AquarioParametro.Parametro.Tipo.ToString();
        }
    }
}

