using CrudClientesProdutos.Application.Product;
using CrudClientesProdutos.Application.Product.DTO;
using CrudClientesProdutos.Server.Controllers.Generics;
using CrudClientesProdutos.Server.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Controllers;

public class ProductController(IProductService productService) : ApplicationV1ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> Get()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products.Select(ProductResponseDTO.FromEntity));
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProductCreateUpdateDTO product)
    {
        var result = await _productService.CreateAsync(product);

        return result.Match(
            product => Ok(ProductResponseDTO.FromEntity(product)),
            error => error.ToIActionResult(this));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, ProductCreateUpdateDTO product)
    {
        var result = await _productService.UpdateAsync(id, product);

        return result.Match(
            product => Ok(ProductResponseDTO.FromEntity(product)),
           error => error.ToIActionResult(this));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long productId)
    {
        var result = await _productService.DeleteAsync(productId);

        return result.Match(
            id => Ok(id),
            error => error.ToIActionResult(this));
    }
}
