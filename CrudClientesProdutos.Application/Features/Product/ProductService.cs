using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Application.Features.Product.DTO;
using CrudClientesProdutos.Domain.Features.Product;
using CrudClientesProdutos.Domain.Abstractions.Repositories;

namespace CrudClientesProdutos.Application.Features.Product;

public class ProductService(
    IProductRepository productRepository,
    IProductValidator productValidator) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IProductValidator _productValidator = productValidator;

    public IPagedEntity<ProductEntity> GetPaged(int take, int page)
         => _productRepository.GetPaged(take, page);

    public Result<ProductEntity, Error> Create(ProductCreateUpdateDTO product)
    {
        var result = _productValidator.Validate(product);

        if (result.IsFailure)
            return result.Error;

        var productEntity = new ProductEntity(
            product.Name,
            product.Price,
            product.Stock);

        return _productRepository.Create(productEntity);
    }

    public Result<ProductEntity, Error> Update(long id, ProductCreateUpdateDTO product)
    {
        var result = _productValidator.Validate(product);

        if (result.IsFailure)
            return result.Error;

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
            return ProductErrors.InvalidId(productId);

        var id = _productRepository.Delete(productId);
        
        return id is null ? ProductErrors.NotFound : id.Value;
    }
}
