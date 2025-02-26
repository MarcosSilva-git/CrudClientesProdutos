using CrudClientesProdutos.Domain.Features.Client;
using CrudClientesProdutos.Domain.Features.Product;
using CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB.Features.Client;
using CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB.Features.Product;
using Microsoft.EntityFrameworkCore;

namespace CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB;

public class InMemoryDbContext : DbContext
{
    public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
    }

    public DbSet<ClientEntity> Clients { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
}
