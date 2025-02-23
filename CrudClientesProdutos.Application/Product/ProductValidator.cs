using CrudClientesProdutos.Application.Product.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Product;

namespace CrudClientesProdutos.Application.Product;

public class ProductValidator : IProductValidator
{
    public Result<ProductCreateUpdateDTO, Error> Validate(ProductCreateUpdateDTO entity)
    {
        if (entity.Price <= 0)
            return ProductErrors.InvalidPrice;

        return entity;
    }
}
