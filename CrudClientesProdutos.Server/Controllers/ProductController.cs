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
    public async Task<ActionResult<PagedResponseDTO<ProductResponseDTO>>> Get(
        [FromQuery] int take = 10,
        [FromQuery] int page = 1)
    {
        var pagedEntity = await _productService.GetPagedAsync(take, page);

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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _productService.DeleteAsync(id);

        return result.Match(
            _ => NoContent(),
            error => error.ToIActionResult(this));
    }
}
