using CrudClientesProdutos.Application.Client.DTO;
using CrudClientesProdutos.Domain;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Client;
using CrudClientesProdutos.Domain.Clients;

namespace CrudClientesProdutos.Application.Client;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<IEnumerable<ClientEntity>> GetAllAsync()
         => await _clientRepository.GetAllAsync();


    public async Task<Result<ClientEntity, Error>> CreateAsync(ClientCreateUpdateDTO client)
    {
        if (client.Name.Length < 3 || client.Name.Length > 100)
            return ClientErrors.InvalidNameSize;

        if (!client.Email.Contains("@"))
            return ClientErrors.InvalidEmail(client.Email);

        var clientEntity = new ClientEntity
        {
            Name = client.Name,
            Email = client.Email,
            PhoneNumber = client.PhoneNumber,
            Active = client.Active
        };

        return await _clientRepository.CreateAsync(clientEntity);
    }

    public async Task<Result<ClientEntity, Error>> UpdateAsync(long id, ClientCreateUpdateDTO client)
    {
        if (client.Name.Length < 3 || client.Name.Length > 100)
            return ClientErrors.InvalidNameSize;

        if (!client.Email.Contains("@"))
            return ClientErrors.InvalidEmail(client.Email);

        var clientEntity = await _clientRepository.FindAsync(id);

        if (clientEntity is null)
            return ClientErrors.NotFound;

        clientEntity.Name = client.Name;
        clientEntity.Email = client.Email;
        clientEntity.PhoneNumber = client.PhoneNumber;
        clientEntity.Active = client.Active;

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
