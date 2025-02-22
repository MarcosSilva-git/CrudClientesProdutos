using CrudClientesProdutos.Application.DTOs.Client;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Clients;

namespace CrudClientesProdutos.Application.Services.Client;

public interface IClientService
{
    Task<IEnumerable<ClientEntity>> GetAllAsync();
    Task<Result<ClientEntity>> CreateAsync(ClientCreateUpdateDTO product);
    Task<Result<long>> DeleteAsync(long productId);
    Task<Result<ClientEntity>> UpdateAsync(long id, ClientCreateUpdateDTO product);
}
