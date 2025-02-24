using CrudClientesProdutos.Domain.Features.Client;
using CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB;

namespace CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB.Repositories;

public class ClientRepository : RepositoryBase<ClientEntity>, IClientRepository
{
    public ClientRepository(InMemoryDbContext context) : base(context)
    {

    }
}
