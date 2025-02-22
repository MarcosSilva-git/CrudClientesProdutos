using CrudClientesProdutos.Domain.Entities;
using CrudClientesProdutos.Domain.Interfaces.Repositories;
using CrudClientesProdutos.Application.Interfaces;

namespace CrudClientesProdutos.Application.Services;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<IEnumerable<ClientEntity>> GetAllAsync()
         => await _clientRepository.GetAllAsync();
}
