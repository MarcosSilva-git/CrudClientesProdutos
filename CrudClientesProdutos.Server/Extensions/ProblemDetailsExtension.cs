using CrudClientesProdutos.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Extensions;

internal static class ProblemDetailsExtension
{
    public static ProblemDetails ToProblemDetails(this Error error)
        => new ProblemDetails()
        {
            Status = error.StatusCode,
            Title = error.Title,
            Detail = error.Description,
        };
}
