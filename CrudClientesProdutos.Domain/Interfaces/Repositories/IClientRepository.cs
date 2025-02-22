using CrudClientesProdutos.Domain.Entities;

namespace CrudClientesProdutos.Domain.Interfaces.Repositories
{
    public interface IClientRepository : IRepository<ClientEntity>
    {
        Task<IEnumerable<ClientEntity>> GetAllAsync();
    }
}
