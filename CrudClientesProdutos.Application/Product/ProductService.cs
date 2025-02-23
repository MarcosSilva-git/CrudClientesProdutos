using CrudClientesProdutos.Domain.Product;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Client;
using CrudClientesProdutos.Application.Product.DTO;

namespace CrudClientesProdutos.Application.Product;

public class ProductService(
    IProductRepository productRepository,
    IProductValidator productValidator) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IProductValidator _productValidator = productValidator;

    public IEnumerable<ProductEntity> GetAll()
         => _productRepository.GetAll();

    public Result<ProductEntity, Error> Create(ProductCreateUpdateDTO product)
    {
        var result = _productValidator.Validate(product);

        if (result.IsFailure)
            return result.Error!;

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
        var result = _productValidator.Validate(product);

        if (result.IsFailure)
            return result.Error!;

        var productEntity = _productRepository.Find(id);

        if (productEntity is null)
            return ProductErrors.NotFound;

        productEntity.Name = product.Name;
        productEntity.Price = product.Price;
        productEntity.Stock = product.Stock;

        return _productRepository.Update(productEntity);
    }

    public Result<long, Error> Delete(long productId)
    {
        if (productId <= 0)
            return CommomErrors.InvalidId(productId);

        var id = _productRepository.Delete(productId);
        
        return id is null ? ProductErrors.NotFound : id.Value;
    }
}
