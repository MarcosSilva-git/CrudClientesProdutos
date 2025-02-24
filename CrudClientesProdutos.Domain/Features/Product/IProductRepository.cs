using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Domain.Features.Product;

public interface IProductRepository : IRepository<ProductEntity>
{
}
