using CrudClientesProdutos.Application.Interfaces;
using CrudClientesProdutos.Domain.Entities;
using CrudClientesProdutos.Server.Controllers.Generics;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Controllers;

public class ProductController(IProductService productService) : ApplicationV1ControllerBase
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
