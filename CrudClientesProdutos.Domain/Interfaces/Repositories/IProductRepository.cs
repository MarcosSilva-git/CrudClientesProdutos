using CrudClientesProdutos.Domain.Entities;

namespace CrudClientesProdutos.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetAllAsync();
    }
}
