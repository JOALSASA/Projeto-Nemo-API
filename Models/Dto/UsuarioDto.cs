namespace Projeto_Nemo.Models.Dto;

public class UsuarioDto
{
    public UsuarioDto()
    {}

    public int Id { get; set; }
    public String NomeUsuario { get; set; } = null!;

    public static UsuarioDto CriarUsuarioDto(Usuario usuario)
    {
        UsuarioDto novoDto = new UsuarioDto();
        novoDto.NomeUsuario = usuario.NomeUsuario;
        novoDto.Id = usuario.Id;
        return novoDto;
    }
}