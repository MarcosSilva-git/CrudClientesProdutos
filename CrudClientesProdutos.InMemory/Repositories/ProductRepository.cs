using CrudClientesProdutos.Domain.Entities;
using CrudClientesProdutos.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrudClientesProdutos.InMemory.Repositories;

public class ProductRepository(InMemoryDbContext inMemoryDbContext) : IProductRepository
{
    private readonly InMemoryDbContext _inMemoryDbContext = inMemoryDbContext;

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        => await _inMemoryDbContext.Product.ToListAsync();
}
