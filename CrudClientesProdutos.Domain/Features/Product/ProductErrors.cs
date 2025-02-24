using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Domain.Features.Product
{
    public static class ProductErrors
    {
        public static Error InvalidId(long id) 
            => new("Product.InvalidId", $"Invalid Id |{id}|");

        public static readonly Error NotFound = new("Product.NotFound", "Product not found");
        public static readonly Error InvalidPrice = new("Product.InvalidPrice", "Can't add product with invalid price");
        public static readonly Error InvalidStockQuantity 
            = new("Product.InvalidStockQuantity", "Can't add product with stock lower than zero");
    }
}
