using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Domain.Entities.Client
{
    public class ClientEntity : IEntity
    {
        public long Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public bool Active { get; set; } = true;
    }
}
