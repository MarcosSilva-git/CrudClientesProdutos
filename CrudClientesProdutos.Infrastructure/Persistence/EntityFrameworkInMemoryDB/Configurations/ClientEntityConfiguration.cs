using CrudClientesProdutos.Domain.Features.Client;
using CrudClientesProdutos.Domain.ValueTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB.Configurations;

internal class ClientEntityConfiguration : IEntityTypeConfiguration<ClientEntity>
{
    public void Configure(EntityTypeBuilder<ClientEntity> builder)
    {
        builder
            .Property(p => p.Name)
            .HasMaxLength(100);
    }
}
