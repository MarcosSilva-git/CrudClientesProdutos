using CrudClientesProdutos.Application.Entities.Client.DTO;
using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Application.Entities.Client;

public interface IClientValidator
{
    public Result<ClientCreateUpdateDTO, Error> Validate(ClientCreateUpdateDTO entity);
}
