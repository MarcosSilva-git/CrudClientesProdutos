using CrudClientesProdutos.Application.Features.Product.DTO;
using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Application.Features.Product;

public interface IProductValidator
{
    public Result<ProductCreateUpdateDTO, Error> Validate(ProductCreateUpdateDTO entity);
}
