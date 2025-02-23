using CrudClientesProdutos.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudClientesProdutos.InMemory.Configurations;

internal class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder
            .Property(p => p.Name)
            .HasMaxLength(100);
    }
}
