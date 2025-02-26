using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        // Não joguei esse ProblemDetails para o ProblemDetailsExtension porque se
        // o dev esquecer de adicionar uma implementação para exceções de aplicação
        // todas os ProblemDetails vão ficar com StatusCode 500
        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
        {
            Status = 500,
            Title = "Server Error",
        });

        return true;
    }
}
