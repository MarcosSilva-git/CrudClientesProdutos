using CrudClientesProdutos.Domain.Product;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Client;
using CrudClientesProdutos.Application.Product.DTO;

namespace CrudClientesProdutos.Application.Product;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public IEnumerable<ProductEntity> GetAll()
         => _productRepository.GetAll();

    public Result<ProductEntity, Error> Create(ProductCreateUpdateDTO product)
    {
        

        var productEntity = new ProductEntity
        {
            Name = product.Name,
            Stock = product.Stock,
            Price = product.Price
        };

        return _productRepository.Create(productEntity);
    }

    public Result<ProductEntity, Error> Update(long id, ProductCreateUpdateDTO product)
    {
        if (product.Price <= 0)
            return ProductErrors.InvalidPrice;

        var productEntity = _productRepository.Find(id);

        if (productEntity is null)
            return ProductErrors.NotFound;

        if (productEntity.Price <= 0)
            return ProductErrors.InvalidPrice;

        productEntity.Name = product.Name;
        productEntity.Price = product.Price;
        productEntity.Stock = product.Stock;

        return _productRepository.Update(productEntity);
    }

    public Result<long, Error> Delete(long productId)
    {
        if (productId <= 0)
            return ClientErrors.InvalidId(productId);

        var id = _productRepository.Delete(productId);
        
        return id is null ? ProductErrors.NotFound : id.Value;
    }
}
