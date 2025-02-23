using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.ValueTypes;

namespace CrudClientesProdutos.Domain.Entities.Client;

public class ClientEntity : IEntity
{
    public long Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required Email Email { get; set; }
    public string? PhoneNumber { get; set; }
    public bool Active { get; set; } = true;
}
