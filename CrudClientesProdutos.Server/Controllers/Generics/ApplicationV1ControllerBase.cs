using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Controllers.Generics;

[ApiVersion(1.0)]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]

public abstract class ApplicationV1ControllerBase : ControllerBase;
