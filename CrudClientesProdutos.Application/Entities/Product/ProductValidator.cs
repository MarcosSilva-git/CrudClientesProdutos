using CrudClientesProdutos.Application.Entities.Product.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Entities.Product;

namespace CrudClientesProdutos.Application.Entities.Product;

public class ProductValidator : IProductValidator
{
    public Result<ProductCreateUpdateDTO, Error> Validate(ProductCreateUpdateDTO entity)
    {
        if (entity.Price <= 0)
            return ProductErrors.InvalidPrice;

        if (entity.Stock < 0)
            return ProductErrors.InvalidStockQuantity;

        return entity;
    }
}
