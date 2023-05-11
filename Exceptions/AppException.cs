using System.Net;

namespace Projeto_Nemo.Exceptions;

public class AppException : BaseException
{
    public AppException(string mensagem, HttpStatusCode status) : base(mensagem)
    {
        Status = status;
    }
}