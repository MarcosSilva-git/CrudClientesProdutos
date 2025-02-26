using CrudClientesProdutos.Domain.Features.Client;

namespace CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB.Features.Client;

public class ClientRepository : RepositoryBase<ClientEntity>, IClientRepository
{
    public ClientRepository(InMemoryDbContext context) : base(context)
    {

    }
}
