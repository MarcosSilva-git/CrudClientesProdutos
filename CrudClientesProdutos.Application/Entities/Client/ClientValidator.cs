using CrudClientesProdutos.Application.Entities.Client.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Entities.Client;
using CrudClientesProdutos.Domain.ValueTypes;

namespace CrudClientesProdutos.Application.Entities.Client;

public class ClientValidator : IClientValidator
{
    public Result<ClientCreateUpdateDTO, Error> Validate(ClientCreateUpdateDTO entity)
    {
        if(entity.Name.Length < 3 || entity.Name.Length > 100)
            return ClientErrors.InvalidNameSize;

        if (!Email.TryParse(entity.Email, out _))
            return CommomErrors.Email.InvalidEmail(entity.Email);

        return entity;
    }
}
