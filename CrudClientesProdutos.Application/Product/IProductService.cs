using CrudClientesProdutos.Application.Product.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Product;

namespace CrudClientesProdutos.Application.Product;

public interface IProductService
{
    IEnumerable<ProductEntity> GetAll();
    Result<ProductEntity, Error> Create(ProductCreateUpdateDTO product);
    Result<long, Error> Delete(long productId);
    Result<ProductEntity, Error> Update(long id, ProductCreateUpdateDTO product);
}
