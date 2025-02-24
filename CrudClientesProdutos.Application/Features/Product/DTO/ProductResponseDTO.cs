using CrudClientesProdutos.Domain.Features.Product;

namespace CrudClientesProdutos.Application.Features.Product.DTO;

public record ProductResponseDTO(
    long Id,
    string Name,
    decimal Price,
    int Stock) 
{
    public static ProductResponseDTO FromEntity(ProductEntity entity)
        => new ProductResponseDTO(entity.Id, entity.Name, entity.Price, entity.Stock);
}
