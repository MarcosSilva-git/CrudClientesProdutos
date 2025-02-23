using CrudClientesProdutos.Domain.Entities.Client;

namespace CrudClientesProdutos.Application.Entities.Client.DTO;

public class ClientResponseDTO
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public bool Active { get; set; } = true;

    public static ClientResponseDTO FromEntity(ClientEntity entity)
        => new ClientResponseDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Email = entity.Email.ToString(),
            PhoneNumber = entity.PhoneNumber,
            Active = entity.Active
        };
}
