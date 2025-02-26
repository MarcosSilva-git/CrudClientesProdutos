using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Controllers.Generics;

[ApiController]
[Route("api/[controller]")]

public abstract class ApplicationV1ControllerBase : ControllerBase;
