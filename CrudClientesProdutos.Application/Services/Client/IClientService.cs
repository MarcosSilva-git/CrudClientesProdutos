using CrudClientesProdutos.Application.DTOs.Client;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Clients;

namespace CrudClientesProdutos.Application.Services.Client;

public interface IClientService
{
    Task<IEnumerable<ClientEntity>> GetAllAsync();
    Task<Result<ClientEntity, Error>> CreateAsync(ClientCreateUpdateDTO product);
    Task<Result<long, Error>> DeleteAsync(long productId);
    Task<Result<ClientEntity, Error>> UpdateAsync(long id, ClientCreateUpdateDTO product);
}
