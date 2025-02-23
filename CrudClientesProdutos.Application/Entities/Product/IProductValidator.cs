using CrudClientesProdutos.Application.Entities.Product.DTO;
using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Application.Entities.Product;

public interface IProductValidator
{
    public Result<ProductCreateUpdateDTO, Error> Validate(ProductCreateUpdateDTO entity);
}
