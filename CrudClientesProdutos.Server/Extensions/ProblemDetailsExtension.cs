using CrudClientesProdutos.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Extensions;

internal static class ProblemDetailsExtension
{
    public static ProblemDetails ToProblemDetails(this Error error)
    {


        return new ProblemDetails()
        {
            Status = 400,
            Title = error.Title,
            Detail = error.Description,
        };
    }
}
