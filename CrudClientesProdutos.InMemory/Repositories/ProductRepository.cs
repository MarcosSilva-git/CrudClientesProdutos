using CrudClientesProdutos.Domain.Products;

namespace CrudClientesProdutos.InMemory.Repositories;

public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
{
    public ProductRepository(InMemoryDbContext context) : base(context)
    {

    }
}
