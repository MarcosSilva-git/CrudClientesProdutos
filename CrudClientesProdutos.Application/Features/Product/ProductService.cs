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

    public async Task<IPagedEntity<ProductEntity>> GetPagedAsync(int take, int page)
         => await _productRepository.GetPagedAsync(take, page);

    public async Task<Result<ProductEntity, Error>> CreateAsync(ProductCreateUpdateDTO product)
    {
        var result = _productValidator.Validate(product);

        if (result.IsFailure)
            return result.Error;

        var productEntity = new ProductEntity(
            product.Name,
            product.Price,
            product.Stock);

        return await _productRepository.CreateAsync(productEntity);
    }

    public async Task<Result<ProductEntity, Error>> UpdateAsync(long id, ProductCreateUpdateDTO product)
    {
        var result = _productValidator.Validate(product);

        if (result.IsFailure)
            return result.Error;

        var productEntity = await _productRepository.FindAsync(id);

        if (productEntity is null)
            return ProductErrors.NotFound;

        productEntity.Name = product.Name;
        productEntity.Price = product.Price;
        productEntity.Stock = product.Stock;

        return await _productRepository.UpdateAsync(productEntity);
    }

    public async Task<Result<long, Error>> DeleteAsync(long productId)
    {
        if (productId <= 0)
            return ProductErrors.InvalidId(productId);

        var id = await _productRepository.DeleteAsync(productId);
        
        return id is null ? ProductErrors.NotFound : id.Value;
    }
}
