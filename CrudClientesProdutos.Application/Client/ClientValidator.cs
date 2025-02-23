using CrudClientesProdutos.Application.Client.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Client;

namespace CrudClientesProdutos.Application.Client;

public class ClientValidator : IClientValidator
{
    public Result<ClientCreateUpdateDTO, Error> Validate(ClientCreateUpdateDTO entity)
    {
        if(entity.Name.Length < 3 || entity.Name.Length > 100)
            return ClientErrors.InvalidNameSize;

        if (!entity.Email.Contains("@"))
            return CommomErrors.Email.InvalidEmail(entity.Email);

        return entity;
    }
}
