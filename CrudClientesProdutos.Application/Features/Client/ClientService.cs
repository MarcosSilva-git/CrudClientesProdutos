using CrudClientesProdutos.Application.Features.Client.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Abstractions.Repositories;
using CrudClientesProdutos.Domain.Features.Client;

namespace CrudClientesProdutos.Application.Features.Client;

public class ClientService(
    IClientRepository clientRepository,
    IClientValidator clientValidator) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly IClientValidator _clientValidator = clientValidator;

    public IPagedEntity<ClientEntity> GetPaged(int take, int page)
         => _clientRepository.GetPaged(take, page);

    public Result<ClientEntity, Error> Create(ClientCreateUpdateDTO client)
    {
        var validationResult = _clientValidator.Validate(client);

        if (validationResult.IsFailure)
            return validationResult.Error;

        var clientEntity = new ClientEntity(
            client.Name, 
            client.Email, 
            client.PhoneNumber);

        return _clientRepository.Create(clientEntity);
    }

    public Result<ClientEntity, Error> Update(long id, ClientCreateUpdateDTO client)
    {
        var validationResult = _clientValidator.Validate(client);

        if (validationResult.IsFailure)
            return validationResult.Error;

        var clientEntity = _clientRepository.Find(id);

        if (clientEntity is null)
            return ClientErrors.NotFound;

        clientEntity.Name = client.Name;
        clientEntity.Email = client.Email;
        clientEntity.PhoneNumber = client.PhoneNumber;
        clientEntity.Active = client.Active;

        return _clientRepository.Update(clientEntity);
    }

    public Result<long, Error> Delete(long clientId)
    {
        if (clientId <= 0)
            return ClientErrors.InvalidId(clientId);

        var id = _clientRepository.Delete(clientId);

        return id is null ? ClientErrors.NotFound : id.Value;
    }
}
