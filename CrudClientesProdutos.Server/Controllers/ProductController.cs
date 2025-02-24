using CrudClientesProdutos.Application.DTO;
using CrudClientesProdutos.Application.Features.Client.DTO;
using CrudClientesProdutos.Application.Features.Product;
using CrudClientesProdutos.Application.Features.Product.DTO;

using CrudClientesProdutos.Server.Controllers.Generics;
using CrudClientesProdutos.Server.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Controllers;

public class ProductController(IProductService productService) : ApplicationV1ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet]
    public ActionResult<PagedResponseDTO<ProductResponseDTO>> Get(
        [FromQuery] int take = 10,
        [FromQuery] int page = 1)
    {
        var pagedEntity = _productService.GetPaged(take, page);

        return Ok(new PagedResponseDTO<ProductResponseDTO>()
        {
            Items = pagedEntity.Items.Select(ProductResponseDTO.FromEntity),
            Page = pagedEntity.Page,
            PageSize = pagedEntity.PageSize,
            TotalItems = pagedEntity.TotalItems,
            TotalPages = pagedEntity.TotalPages
        });
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

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var result = _productService.Delete(id);

        return result.Match(
            id => Ok(id),
            error => error.ToIActionResult(this));
    }
}
