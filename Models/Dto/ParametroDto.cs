using System.Text.Json.Serialization;
using Projeto_Nemo.Models.Enums;

namespace Projeto_Nemo.Models.Dto;

public class ParametroDto
{
    public int Id { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TipoParametro Tipo { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }

    public ParametroDto(Parametro parametro)
    {
        Id = parametro.Id;
        Tipo = parametro.Tipo;
        Min = parametro.Min;
        Max = parametro.Max;
    }
}