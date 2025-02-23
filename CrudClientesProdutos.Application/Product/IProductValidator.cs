using CrudClientesProdutos.Application.Product.DTO;
using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Application.Product;

public interface IProductValidator
{
    public Result<ProductCreateUpdateDTO, Error> Validate(ProductCreateUpdateDTO entity);
}
