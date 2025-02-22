using CrudClientesProdutos.Application.DTOs.Client;
using CrudClientesProdutos.Application.Services.Client;
using CrudClientesProdutos.Server.Controllers.Generics;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Controllers;

public class ClientController(IClientService clientService) : ApplicationV1ControllerBase
{
    private readonly IClientService _clientService = clientService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientResponseDTO>>> Get()
    {
        var clients = await _clientService.GetAllAsync();

        return Ok(clients.Select(ClientResponseDTO.FromEntity));
    }

    [HttpPost]
    public async Task<IActionResult> Post(ClientCreateUpdateDTO client)
    {
        var result = await _clientService.CreateAsync(client);

        return result.Match(
            client => Ok(ClientResponseDTO.FromEntity(client)),
            ErrorResult);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, ClientCreateUpdateDTO client)
    {
        var result = await _clientService.UpdateAsync(id, client);

        return result.Match(
            client => Ok(ClientResponseDTO.FromEntity(client)),
            ErrorResult);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long clientId)
    {
        var result = await _clientService.DeleteAsync(clientId);

        return result.Match(id => Ok(id), ErrorResult);
    }
}
