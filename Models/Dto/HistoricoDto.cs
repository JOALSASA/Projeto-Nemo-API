namespace Projeto_Nemo.Models.Dto;

public class HistoricoDto
{
    public int Id { get; set; }
    public int Valor { get; set; }
    public DateTime Hora { get; set; }
    public int AquarioParametroId { get; set;}
    public UsuarioDto UsuarioDto { get; set; }

    public HistoricoDto(Historico historico)
    {
        Id = historico.Id;
        Valor = historico.Valor;
        Hora = historico.Hora;
        AquarioParametroId = historico.AquarioParametro.Id;
        UsuarioDto = new UsuarioDto(historico.Usuario);
    } 
}