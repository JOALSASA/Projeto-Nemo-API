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
            await HandleExceptionAsync(context, ex);
        }
    }

    // TODO: Logar o stackTrace da aplicação
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Tratamento default
        string mensagem;
        HttpStatusCode status;

        try
        {
            var baseException = (BaseException)exception;
            mensagem = baseException.Message;
            status = baseException.Status;
        }
        catch (Exception _)
        {
            mensagem = exception.Message;
            status = HttpStatusCode.InternalServerError;
        }
        
        var response = JsonSerializer.Serialize(new { mensagem, status });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;
        return context.Response.WriteAsync(response);
    }
}