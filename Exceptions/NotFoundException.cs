using System.Net;

namespace Projeto_Nemo.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string mensagem) : base(mensagem)
    {
        Status = HttpStatusCode.NotFound;
    }
}