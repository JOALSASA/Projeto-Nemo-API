using System.Net;

namespace Projeto_Nemo.Exceptions;


public class ConflictException : BaseException
{
    public ConflictException(string mensagem) : base(mensagem)
    {
        Status = HttpStatusCode.Conflict;
    }
}