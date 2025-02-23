using CrudClientesProdutos.Domain.Entities.Client;
using CrudClientesProdutos.Domain.ValueTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudClientesProdutos.InMemory.Configurations;

internal class ClientEntityConfiguration : IEntityTypeConfiguration<ClientEntity>
{
    public void Configure(EntityTypeBuilder<ClientEntity> builder)
    {
        builder
            .Property(p => p.Name)
        .HasMaxLength(100);

        builder
            .Property(c => c.Email)
            .HasConversion(
                email => email.ToString(),
                value => Email.Parse(value));
    }
}
