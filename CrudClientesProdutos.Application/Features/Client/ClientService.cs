using CrudClientesProdutos.Application.Features.Client.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Abstractions.Repositories;
using CrudClientesProdutos.Domain.Features.Client;
using CrudClientesProdutos.Domain.ValueTypes;

namespace CrudClientesProdutos.Application.Features.Client;

public class ClientService(
    IClientRepository clientRepository,
    IClientValidator clientValidator) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly IClientValidator _clientValidator = clientValidator;

    public async Task<IPagedEntity<ClientEntity>> GetPagedAsync(int take, int page)
         => await _clientRepository.GetPagedAsync(take, page);

    public async Task<Result<ClientEntity, Error>> CreateAsync(ClientCreateUpdateDTO client)
    {
        var validationResult = _clientValidator.Validate(client);

        if (validationResult.IsFailure)
            return validationResult.Error;

        var clientEntity = new ClientEntity(
            client.Name, 
            client.Email,
            client.PhoneNumber is null
                ? (PhoneNumberType?)null
                : new PhoneNumberType(client.PhoneNumber),
            client.Active);

        return await _clientRepository.CreateAsync(clientEntity);
    }

    public async Task<Result<ClientEntity, Error>> UpdateAsync(long id, ClientCreateUpdateDTO client)
    {
        var validationResult = _clientValidator.Validate(client);

        if (validationResult.IsFailure)
            return validationResult.Error;

        var clientEntity = await _clientRepository.FindAsync(id);

        if (clientEntity is null)
            return ClientErrors.NotFound;

        clientEntity.Name = client.Name;
        clientEntity.Email = client.Email;
        clientEntity.Active = client.Active;
        clientEntity.PhoneNumber = client.PhoneNumber is null 
            ? (PhoneNumberType?)null 
            : new PhoneNumberType(client.PhoneNumber);

        return await _clientRepository.UpdateAsync(clientEntity);
    }

    public async Task<Result<long, Error>> DeleteAsync(long clientId)
    {
        if (clientId <= 0)
            return ClientErrors.InvalidId(clientId);

        var id = await _clientRepository.DeleteAsync(clientId);

        return id is null ? ClientErrors.NotFound : id.Value;
    }
}
