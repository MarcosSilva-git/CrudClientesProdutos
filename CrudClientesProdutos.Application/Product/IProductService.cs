using CrudClientesProdutos.Application.Product.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Products;

namespace CrudClientesProdutos.Application.Product;

public interface IProductService
{
    Task<IEnumerable<ProductEntity>> GetAllAsync();
    Task<Result<ProductEntity, Error>> CreateAsync(ProductCreateUpdateDTO product);
    Task<Result<long, Error>> DeleteAsync(long productId);
    Task<Result<ProductEntity, Error>> UpdateAsync(long id, ProductCreateUpdateDTO product);
}
