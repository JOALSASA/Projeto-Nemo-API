namespace Projeto_Nemo.Models.Dto;

public class AquarioParametroDto
{
    public int Id { get; set; }
    public int AquariosId { get; set; }
    public int ParametrosId { get; set; }
    public ParametroDto ParametroDto { get; set; }
    public int Valor { get; set; }

    public AquarioParametroDto(AquarioParametro aquarioParametro)
    {
        Id = aquarioParametro.Id;
        AquariosId = aquarioParametro.AquariosId;
        ParametrosId = aquarioParametro.ParametrosId;
        ParametroDto = new ParametroDto(aquarioParametro.Parametro);
        Valor = aquarioParametro.Valor;
    }
}