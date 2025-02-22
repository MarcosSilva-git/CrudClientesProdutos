using CrudClientesProdutos.Application.DTOs.Product;
using CrudClientesProdutos.Domain.Product;
using CrudClientesProdutos.Domain.Products;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain;
using CrudClientesProdutos.Domain.Client;

namespace CrudClientesProdutos.Application.Services.Product;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
         => await _productRepository.GetAllAsync();


    public async Task<Result<ProductEntity>> CreateAsync(ProductCreateUpdateDTO product)
    {
        if (product.Price <= 0)
            return ProductErrors.InvalidPrice;

        var productEntity = new ProductEntity
        {
            Name = product.Name,
            Stock = product.Stock,
            Price = product.Price
        };

        return await _productRepository.CreateAsync(productEntity);
    }

    public async Task<Result<ProductEntity>> UpdateAsync(long id, ProductCreateUpdateDTO product)
    {
        if (product.Price <= 0)
            return ProductErrors.InvalidPrice;

        var productEntity = await _productRepository.FindAsync(id);

        if (productEntity is null)
            return ProductErrors.NotFound;

        if (productEntity.Price <= 0)
            return ProductErrors.InvalidPrice;

        productEntity.Name = product.Name;
        productEntity.Price = product.Price;
        productEntity.Stock = product.Stock;

        return await _productRepository.UpdateAsync(productEntity);
    }

    public async Task<Result<long>> DeleteAsync(long productId)
    {
        if (productId <= 0)
            return CommomErrors.InvalidId;

        var id = await _productRepository.DeleteAsync(productId);
        
        return id is null ? ProductErrors.NotFound : id.Value;
    }
}
