using CrudClientesProdutos.Domain.Clients;
using CrudClientesProdutos.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace CrudClientesProdutos.InMemory
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options) { }

        public DbSet<ClientEntity> Client { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
    }
}
