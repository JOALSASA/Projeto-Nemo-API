using System.Net;
using System.Text.Json;

namespace Projeto_Nemo.Controllers.Middleware;

public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    
    public GlobalErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await handleExceptionAsync(context, ex);
        }
        
        
    }

    private static Task handleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode status;
        // TODO: Logar o stackTrace da aplicação
        string stackTrace = String.Empty;
        string mensagem;
        var exceptionType = exception.GetType();

        // TODO: Adicionar o restante das exceções aqui
        
        // Trata default
        mensagem = exception.Message;
        status = HttpStatusCode.InternalServerError;

        var response = JsonSerializer.Serialize(new { mensagem, status });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) status;
        return context.Response.WriteAsync(response);
    }
}