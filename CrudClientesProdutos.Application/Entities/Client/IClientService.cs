using CrudClientesProdutos.Application.Entities.Client.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Entities.Client;

namespace CrudClientesProdutos.Application.Entities.Client;

public interface IClientService
{
    IEnumerable<ClientEntity> GetAll();
    Result<ClientEntity, Error> Create(ClientCreateUpdateDTO product);
    Result<long, Error> Delete(long productId);
    Result<ClientEntity, Error> Update(long id, ClientCreateUpdateDTO product);
}
