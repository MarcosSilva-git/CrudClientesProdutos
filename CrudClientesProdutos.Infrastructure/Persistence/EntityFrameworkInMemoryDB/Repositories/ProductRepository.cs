using CrudClientesProdutos.Domain.Features.Product;
using CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB;

namespace CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB.Repositories;

public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
{
    public ProductRepository(InMemoryDbContext context) : base(context)
    {

    }
}
