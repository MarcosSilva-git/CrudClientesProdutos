using Asp.Versioning;
using CrudClientesProdutos.Application.Interfaces;
using CrudClientesProdutos.Domain.Entities;
using CrudClientesProdutos.Server.Controllers.Generics;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Controllers.Generics;


[ApiVersion(2.0)]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<ProductEntity>>> GetAll()
    {
        var products = await _productService.GetAllAsync();

        if (products is null)
            return BadRequest("No products found");

        return Ok(products);
    }
}
