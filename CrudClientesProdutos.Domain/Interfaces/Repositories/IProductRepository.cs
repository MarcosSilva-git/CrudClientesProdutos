using CrudClientesProdutos.Domain.Entities;

namespace CrudClientesProdutos.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
        IEnumerable<ProductEntity> GetAll();
    }
}
