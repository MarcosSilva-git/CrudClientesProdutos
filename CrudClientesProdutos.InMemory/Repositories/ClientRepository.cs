using CrudClientesProdutos.Domain.Client;

namespace CrudClientesProdutos.InMemory.Repositories;

public class ClientRepository : RepositoryBase<ClientEntity>, IClientRepository
{
    public ClientRepository(InMemoryDbContext context) : base(context)
    {

    }
}
