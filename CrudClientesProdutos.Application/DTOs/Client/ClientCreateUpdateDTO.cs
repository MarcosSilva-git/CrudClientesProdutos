using System.ComponentModel.DataAnnotations;

namespace CrudClientesProdutos.Application.DTOs.Client;

public record ClientCreateUpdateDTO 
{
    [Required, MinLength(3), StringLength(100)]
    public string Name { get; init; } = string.Empty;
    
    [Required]
    public string Email { get; init; } = string.Empty;

    public string PhoneNumber { get; init; } = string.Empty;

    public bool Active { get; init; } = true;
}
