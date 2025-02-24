using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.ValueTypes;

namespace CrudClientesProdutos.Domain.Features.Product;

public class ProductEntity : IEntity
{
    public long Id { get; init; }
    public NameType Name { get; set; }
    public PriceType Price { get; set; }
    public StockType Stock { get; set; }

    private ProductEntity() {  }

    public ProductEntity(string name, decimal price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }
}
