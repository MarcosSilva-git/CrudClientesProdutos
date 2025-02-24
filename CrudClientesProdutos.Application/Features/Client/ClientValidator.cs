using CrudClientesProdutos.Application.Features.Client.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Features.Client;
using CrudClientesProdutos.Domain.ValueTypes;

namespace CrudClientesProdutos.Application.Features.Client;

public class ClientValidator : IClientValidator
{
    public Result<ClientCreateUpdateDTO, Error> Validate(ClientCreateUpdateDTO entity)
    {
        if (entity.Name.Length < 3 || entity.Name.Length > 100)
            return ClientErrors.InvalidNameSize;

        if (!Email.TryParse(entity.Email, out _))
            return CommomErrors.Email.InvalidEmail(entity.Email);

        if (entity.PhoneNumber is not null && !PhoneNumber.TryParse(entity.PhoneNumber, out _))
            return CommomErrors.PhoneNumber.InvalidPhoneNumber(entity.PhoneNumber);

        return entity;
    }
}
