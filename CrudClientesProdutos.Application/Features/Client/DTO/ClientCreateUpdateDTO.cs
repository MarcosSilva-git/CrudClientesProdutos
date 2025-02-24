using System.ComponentModel.DataAnnotations;

namespace CrudClientesProdutos.Application.Features.Client.DTO;

public record ClientCreateUpdateDTO 
{
    [Required]
    public string Name { get; init; } = string.Empty;
    
    [Required]
    public string Email { get; init; } = string.Empty;

    public string? PhoneNumber { get; init; }
}
