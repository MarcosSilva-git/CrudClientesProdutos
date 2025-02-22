using CrudClientesProdutos.Domain.Entities;

namespace CrudClientesProdutos.Domain.Interfaces.Repositories
{
    public interface IClientRepository : IRepository<ClientEntity>
    {
        IEnumerable<ClientEntity> GetAll();
    }
}
