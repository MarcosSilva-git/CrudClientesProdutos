using CrudClientesProdutos.Application.Features.Client.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Abstractions.Repositories;

namespace CrudClientesProdutos.Application.Features.Client;

public interface IClientService
{
    IPagedEntity<ClientEntity> GetPaged(int take, int page);
    Result<ClientEntity, Error> Create(ClientCreateUpdateDTO product);
    Result<long, Error> Delete(long productId);
    Result<ClientEntity, Error> Update(long id, ClientCreateUpdateDTO product);
}
