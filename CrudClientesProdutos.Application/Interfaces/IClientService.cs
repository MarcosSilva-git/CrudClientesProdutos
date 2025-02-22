using CrudClientesProdutos.Domain.Entities;

namespace CrudClientesProdutos.Application.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientEntity>> GetAllAsync();
}
