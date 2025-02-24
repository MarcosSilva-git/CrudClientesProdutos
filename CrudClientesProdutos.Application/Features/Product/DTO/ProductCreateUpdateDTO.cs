using System.ComponentModel.DataAnnotations;

namespace CrudClientesProdutos.Application.Features.Product.DTO;

public record ProductCreateUpdateDTO
{
    [Required]
    public string Name { get; init; } = string.Empty;

    [Required]
    public decimal Price { get; init; }

    public int Stock { get; init; }
}
