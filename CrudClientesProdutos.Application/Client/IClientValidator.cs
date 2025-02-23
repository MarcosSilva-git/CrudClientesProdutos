using CrudClientesProdutos.Application.Client.DTO;
using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Application.Client;

public interface IClientValidator
{
    public Result<ClientCreateUpdateDTO, Error> Validate(ClientCreateUpdateDTO entity);
}
