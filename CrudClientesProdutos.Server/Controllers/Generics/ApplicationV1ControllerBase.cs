using Asp.Versioning;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Server.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Controllers.Generics;

[ApiVersion(1.0)]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]

public abstract class ApplicationV1ControllerBase : ControllerBase
{
    
}
