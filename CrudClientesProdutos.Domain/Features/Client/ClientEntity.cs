using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.ValueTypes;

public class ClientEntity : IEntity
{
    public long Id { get; init; }

    public NameType Name { get; set; }
    public EmailType Email { get; set; }
    public PhoneNumberType? PhoneNumber { get; set; }
    public bool Active { get; set; } = true;

    private ClientEntity() { }

    public ClientEntity(NameType name, EmailType email, PhoneNumberType? phoneNumber)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}
