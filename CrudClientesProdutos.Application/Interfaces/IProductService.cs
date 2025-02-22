using CrudClientesProdutos.Domain.Entities;

namespace CrudClientesProdutos.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductEntity>> GetAllAsync();
}
