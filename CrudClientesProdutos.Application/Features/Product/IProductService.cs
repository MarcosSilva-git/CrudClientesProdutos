using CrudClientesProdutos.Application.Features.Product.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Abstractions.Repositories;
using CrudClientesProdutos.Domain.Features.Product;

namespace CrudClientesProdutos.Application.Features.Product;

public interface IProductService
{
    Task<IPagedEntity<ProductEntity>> GetPagedAsync(int take, int page);
    Task<Result<ProductEntity, Error>> CreateAsync(ProductCreateUpdateDTO product);
    Task<Result<long, Error>> DeleteAsync(long productId);
    Task<Result<ProductEntity, Error>> UpdateAsync(long id, ProductCreateUpdateDTO product);
}
