using CrudClientesProdutos.Application.Features.Client.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Abstractions.Repositories;

namespace CrudClientesProdutos.Application.Features.Client;

public interface IClientService
{
    Task<IPagedEntity<ClientEntity>> GetPagedAsync(int take, int page);
    Task<Result<ClientEntity, Error>> CreateAsync(ClientCreateUpdateDTO product);
    Task<Result<long, Error>> DeleteAsync(long productId);
    Task<Result<ClientEntity, Error>> UpdateAsync(long id, ClientCreateUpdateDTO product);
}
