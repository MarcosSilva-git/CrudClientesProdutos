using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Domain.Product;

public class ProductEntity : IEntity
{
    public long Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required decimal Price { get; set; }
    public int Stock { get; set; }
}
