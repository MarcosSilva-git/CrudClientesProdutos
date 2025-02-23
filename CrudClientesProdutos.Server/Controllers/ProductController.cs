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
    public ActionResult<IEnumerable<ProductResponseDTO>> Get()
    {
        var products = _productService.GetAll();
        return Ok(products.Select(ProductResponseDTO.FromEntity));
    }

    [HttpPost]
    public IActionResult Post(ProductCreateUpdateDTO product)
    {
        var result = _productService.Create(product);

        return result.Match(
            product => Ok(ProductResponseDTO.FromEntity(product)),
            error => error.ToIActionResult(this));
    }

    [HttpPut("{id}")]
    public IActionResult Put(long id, ProductCreateUpdateDTO product)
    {
        var result = _productService.Update(id, product);

        return result.Match(
            product => Ok(ProductResponseDTO.FromEntity(product)),
           error => error.ToIActionResult(this));
    }

    [HttpDelete]
    public IActionResult Delete(long productId)
    {
        var result = _productService.Delete(productId);

        return result.Match(
            id => Ok(id),
            error => error.ToIActionResult(this));
    }
}
