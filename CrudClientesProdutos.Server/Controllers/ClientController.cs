using CrudClientesProdutos.Application.Features.Client;
using CrudClientesProdutos.Application.Features.Client.DTO;
using CrudClientesProdutos.Server.Controllers.Generics;
using CrudClientesProdutos.Server.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientesProdutos.Server.Controllers;

public class ClientController(IClientService clientService) : ApplicationV1ControllerBase
{
    private readonly IClientService _clientService = clientService;

    [HttpGet]
    public ActionResult<IEnumerable<ClientResponseDTO>> Get()
    {
        var clients = _clientService.GetAll();

        return Ok(clients.Select(ClientResponseDTO.FromEntity));
    }

    [HttpPost]
    public IActionResult Post(ClientCreateUpdateDTO client)
    {
        var result = _clientService.Create(client);

        return result.Match(
            client => Ok(ClientResponseDTO.FromEntity(client)),
            error => error.ToIActionResult(this));
    }

    [HttpPut("{id}")]
    public IActionResult Put(long id, ClientCreateUpdateDTO client)
    {
        var result = _clientService.Update(id, client);

        return result.Match(
            client => Ok(ClientResponseDTO.FromEntity(client)),
             error => error.ToIActionResult(this));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var result = _clientService.Delete(id);

        return result.Match(
            id => Ok(id), 
            error => error.ToIActionResult(this));
    }
}
