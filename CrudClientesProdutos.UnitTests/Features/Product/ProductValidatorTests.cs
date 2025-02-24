using CrudClientesProdutos.Application.Features.Product;
using CrudClientesProdutos.Application.Features.Product.DTO;
using CrudClientesProdutos.Domain.Features.Product;

namespace CrudClientesProdutos.UnitTests.Features.Product;

public class ProductValidatorTests
{
    private readonly ProductValidator _productValidator;

    public ProductValidatorTests()
    {
        _productValidator = new ProductValidator();
    }

    [Fact]
    public void Validate_WithValidProduct_ShouldReturnSuccess()
    {
        // Arrange
        var product = new ProductCreateUpdateDTO { Name = "Laptop", Price = 1200, Stock = 5 };

        // Act
        var result = _productValidator.Validate(product);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(product, result.Value);
    }

    [Fact]
    public void Validate_WithZeroPrice_ShouldReturnError()
    {
        // Arrange
        var product = new ProductCreateUpdateDTO { Name = "Laptop", Price = 0, Stock = 5 };

        // Act
        var result = _productValidator.Validate(product);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(ProductErrors.InvalidPrice, result.Error);
    }

    [Fact]
    public void Validate_WithNegativePrice_ShouldReturnError()
    {
        // Arrange
        var product = new ProductCreateUpdateDTO { Name = "Laptop", Price = -100, Stock = 5 };

        // Act
        var result = _productValidator.Validate(product);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(ProductErrors.InvalidPrice, result.Error);
    }
}
