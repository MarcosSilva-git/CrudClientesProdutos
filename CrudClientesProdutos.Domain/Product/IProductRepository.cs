using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Domain.Products
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
    }
}
