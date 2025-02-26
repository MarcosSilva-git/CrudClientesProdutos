using CrudClientesProdutos.Domain.Features.Product;

namespace CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB.Features.Product;

public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
{
    public ProductRepository(InMemoryDbContext context) : base(context)
    {

    }
}
