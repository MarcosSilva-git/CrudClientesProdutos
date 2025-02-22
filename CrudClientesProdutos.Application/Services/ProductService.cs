using CrudClientesProdutos.Application.Interfaces;
using CrudClientesProdutos.Domain.Entities;
using CrudClientesProdutos.Domain.Interfaces.Repositories;

namespace CrudClientesProdutos.Application.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
         => await _productRepository.GetAllAsync();
}
