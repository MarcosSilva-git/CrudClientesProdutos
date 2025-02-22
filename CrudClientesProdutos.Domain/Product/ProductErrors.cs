using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Domain.Product
{
    public static class ProductErrors
    {
        public static readonly Error NotFound = new("Product.NotFound", "Product not found", 404);
        public static readonly Error InvalidPrice = new("Product.InvalidPrice", "Can't add product with invalid price");
    }
}
