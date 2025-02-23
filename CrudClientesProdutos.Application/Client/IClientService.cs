using CrudClientesProdutos.Application.Client.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Client;

namespace CrudClientesProdutos.Application.Client;

public interface IClientService
{
    IEnumerable<ClientEntity> GetAll();
    Result<ClientEntity, Error> Create(ClientCreateUpdateDTO product);
    Result<long, Error> Delete(long productId);
    Result<ClientEntity, Error> Update(long id, ClientCreateUpdateDTO product);
}
