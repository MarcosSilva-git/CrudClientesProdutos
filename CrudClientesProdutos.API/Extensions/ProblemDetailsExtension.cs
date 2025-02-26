using CrudClientesProdutos.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Extensions;

internal static class ProblemDetailsExtension
{
    public static ProblemDetails ToProblemDetails(this Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorEnum.DomainRuleError => 400,
            ErrorEnum.NotFounError => 404,
            _ => throw new ArgumentOutOfRangeException(nameof(error.Type),
                $"An error occurred while trying to convert the error type into a status code. " +
                $"ErrorType \"{error.Type}\" is not recognized.")
        };

        return new ProblemDetails()
        {
            Status = statusCode,
            Title = error.Title,
            Detail = error.Description,
        };
    }
}
