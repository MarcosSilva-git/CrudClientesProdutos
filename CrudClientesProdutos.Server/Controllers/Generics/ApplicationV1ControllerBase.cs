using Asp.Versioning;
using CrudClientesProdutos.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Controllers.Generics;

[ApiVersion(1.0)]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]

public abstract class ApplicationV1ControllerBase : ControllerBase
{
    protected IActionResult ErrorResult(Error error)
    {
        return error.StatusCode switch
        {
            401 => Unauthorized(error.Description), 
            403 => Forbid(),                        
            404 => NotFound(error.Description),     
            422 => UnprocessableEntity(error.Description), 
            500 => StatusCode(500, error.Description),
            _ => BadRequest(error.Description)
        };
    }
}
