using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.ValueTypes;

public class ClientEntity : IEntity
{
    public long Id { get; init; }

    public NameType Name { get; set; }
    public EmailType Email { get; set; }
    public PhoneNumberType? PhoneNumber { get; set; }
    public bool Active { get; set; }

    private ClientEntity() { }

    public ClientEntity(string name, string email, string? phoneNumber, bool active)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber is null ? (PhoneNumberType?)null : new PhoneNumberType(phoneNumber);
        Active = active;
    }
}
