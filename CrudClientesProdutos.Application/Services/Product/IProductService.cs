using CrudClientesProdutos.Application.DTOs.Product;
using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Domain.Products;

public interface IProductService
{
    Task<IEnumerable<ProductEntity>> GetAllAsync();
    Task<Result<ProductEntity, Error>> CreateAsync(ProductCreateUpdateDTO product);
    Task<Result<long, Error>> DeleteAsync(long productId);
    Task<Result<ProductEntity, Error>> UpdateAsync(long id, ProductCreateUpdateDTO product);
}
