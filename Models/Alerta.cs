using Projeto_Nemo.Models.Enums;

namespace Projeto_Nemo.Models;

public class Alerta
{
    public int Id { get; set; }
    public String Nome { get; set; } = null!;
    public int Min { get; set; }
    public int Max { get; set; }
    public EstadoAlerta EstadoAlerta { get; set; }
    public Aquario Aquario { get; set; } = null!; 
    public AquarioParametro AquarioParametro { get; set; } = new();
}