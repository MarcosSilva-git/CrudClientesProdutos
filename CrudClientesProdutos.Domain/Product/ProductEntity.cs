using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Domain.Products
{
    public class ProductEntity : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
