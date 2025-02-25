using CrudClientesProdutos.Application.DTO;
using CrudClientesProdutos.Application.Features.Client;
using CrudClientesProdutos.Application.Features.Client.DTO;
using CrudClientesProdutos.Application.Features.Product.DTO;
using CrudClientesProdutos.Server.Controllers.Generics;
using CrudClientesProdutos.Server.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Controllers;

public class ClientController(IClientService clientService) : ApplicationV1ControllerBase
{
    private readonly IClientService _clientService = clientService;

    [HttpGet]
    public async Task<ActionResult<PagedResponseDTO<ClientResponseDTO>>> Get(
        [FromQuery] int take = 10,
        [FromQuery] int page = 1)
    {
        var pagedEntity = await _clientService.GetPagedAsync(take, page);

        return Ok(new PagedResponseDTO<ClientResponseDTO>()
        {
            Items = pagedEntity.Items.Select(ClientResponseDTO.FromEntity),
            Page = pagedEntity.Page,
            PageSize = pagedEntity.PageSize,
            TotalItems = pagedEntity.TotalItems,
            TotalPages = pagedEntity.TotalPages
        });
    }

    [HttpPost]
    public async Task<IActionResult> Post(ClientCreateUpdateDTO client)
    {
        var result = await _clientService.CreateAsync(client);

        return result.Match(
            client => Ok(ClientResponseDTO.FromEntity(client)),
            error => error.ToIActionResult(this));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, ClientCreateUpdateDTO client)
    {
        var result = await _clientService.UpdateAsync(id, client);

        return result.Match(
            client => Ok(ClientResponseDTO.FromEntity(client)),
             error => error.ToIActionResult(this));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _clientService.DeleteAsync(id);

        return result.Match(
            id => NoContent(), 
            error => error.ToIActionResult(this));
    }
}
