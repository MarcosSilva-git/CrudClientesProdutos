using CrudClientesProdutos.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Extensions;

public static class ActionResulExtension
{
    public static IActionResult ToIActionResult(ProblemDetails problemDetails, ControllerBase controller)
        => problemDetails.Status switch
        {
            400 => controller.BadRequest(problemDetails),
            401 => controller.Unauthorized(problemDetails),
            403 => controller.Forbid(),
            404 => controller.NotFound(problemDetails),
            422 => controller.UnprocessableEntity(problemDetails),
            _ => throw new ArgumentOutOfRangeException(nameof(problemDetails.Status),
                $"Unexpected status code: {problemDetails.Status}")
        };

    public static IActionResult ToIActionResult(this Error error, ControllerBase controller)
        => ToIActionResult(error.ToProblemDetails(), controller);
}
