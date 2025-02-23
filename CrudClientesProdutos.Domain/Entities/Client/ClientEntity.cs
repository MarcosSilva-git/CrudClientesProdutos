using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.ValueTypes;

namespace CrudClientesProdutos.Domain.Entities.Client;

public class ClientEntity : IEntity
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required Email Email { get; set; }
    public PhoneNumber? PhoneNumber { get; set; }
    public bool Active { get; set; } = true;
}
