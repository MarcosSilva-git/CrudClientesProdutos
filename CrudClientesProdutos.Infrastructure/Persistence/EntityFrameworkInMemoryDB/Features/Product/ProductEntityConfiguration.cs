using CrudClientesProdutos.Domain.Features.Product;
using CrudClientesProdutos.Domain.ValueTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB.Features.Product;

internal class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder
            .Property(p => p.Name)
            .HasMaxLength(NameType.DefaultMaxLength);
    }
}
