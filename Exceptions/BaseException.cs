using System.Net;

namespace Projeto_Nemo.Exceptions;

public class BaseException : Exception
{
    public HttpStatusCode Status { get; set; } = HttpStatusCode.InternalServerError;

    public BaseException(string mensagem) : base(mensagem)
    {
    }
}