using System.ComponentModel.DataAnnotations;

namespace CrudClientesProdutos.Application.Product.DTO;

public record ProductCreateUpdateDTO
{
    [Required, MinLength(3), StringLength(100)]
    public string Name { get; init; } = string.Empty;

    public decimal Price { get; init; }

    public int Stock { get; init; }
}
