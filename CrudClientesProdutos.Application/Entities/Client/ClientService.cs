using CrudClientesProdutos.Application.Entities.Client.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Entities.Client;

namespace CrudClientesProdutos.Application.Entities.Client;

public class ClientService(
    IClientRepository clientRepository,
    IClientValidator clientValidator) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly IClientValidator _clientValidator = clientValidator;

    public IEnumerable<ClientEntity> GetAll()
         => _clientRepository.GetAll();


    public Result<ClientEntity, Error> Create(ClientCreateUpdateDTO client)
    {
        var validationResult = _clientValidator.Validate(client);

        if (validationResult.IsFailure)
            return validationResult.Error!;

        var clientEntity = new ClientEntity
        {
            Name = client.Name,
            Email = client.Email,
            PhoneNumber = client.PhoneNumber,
            Active = client.Active
        };

        return _clientRepository.Create(clientEntity);
    }

    public Result<ClientEntity, Error> Update(long id, ClientCreateUpdateDTO client)
    {
        var validationResult = _clientValidator.Validate(client);

        if (validationResult.IsFailure)
            return validationResult.Error!;

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
