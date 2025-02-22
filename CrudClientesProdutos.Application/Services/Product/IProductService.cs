using CrudClientesProdutos.Application.DTOs.Product;
using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Domain.Products;

public interface IProductService
{
    Task<IEnumerable<ProductEntity>> GetAllAsync();
    Task<Result<ProductEntity>> CreateAsync(ProductCreateUpdateDTO product);
    Task<Result<long>> DeleteAsync(long productId);
    Task<Result<ProductEntity>> UpdateAsync(long id, ProductCreateUpdateDTO product);
}
