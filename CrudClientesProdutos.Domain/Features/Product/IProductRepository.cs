using CrudClientesProdutos.Domain.Abstractions.Repositories;

namespace CrudClientesProdutos.Domain.Features.Product;

public interface IProductRepository : IRepository<ProductEntity>
{
}
