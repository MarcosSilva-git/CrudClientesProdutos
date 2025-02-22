using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Domain.Clients
{
    public class ClientEntity : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public bool Active { get; set; } = true;
    }
}
