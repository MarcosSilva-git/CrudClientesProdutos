using CrudClientesProdutos.Domain.Client;
using CrudClientesProdutos.Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace CrudClientesProdutos.InMemory;

public class InMemoryDbContext : DbContext
{
    public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
         => modelBuilder.ApplyConfigurationsFromAssembly(typeof(InMemoryDbContext).Assembly);

    public DbSet<ClientEntity> Clients { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
}
