using CrudClientesProdutos.Application.Features.Product.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Abstractions.Repositories;
using CrudClientesProdutos.Domain.Features.Product;

namespace CrudClientesProdutos.Application.Features.Product;

public interface IProductService
{
    IPagedEntity<ProductEntity> GetPaged(int take, int page);
    Result<ProductEntity, Error> Create(ProductCreateUpdateDTO product);
    Result<long, Error> Delete(long productId);
    Result<ProductEntity, Error> Update(long id, ProductCreateUpdateDTO product);
}
