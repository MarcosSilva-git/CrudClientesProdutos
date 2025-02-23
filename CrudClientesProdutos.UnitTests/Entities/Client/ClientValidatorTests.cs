using CrudClientesProdutos.Application.Entities.Client.DTO;
using CrudClientesProdutos.Application.Entities.Client;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Entities.Client;

namespace CrudClientesProdutos.UnitTests.Entities.Client;

public class ClientValidatorTests
{
    private readonly ClientValidator _clientValidator;

    public ClientValidatorTests()
    {
        _clientValidator = new ClientValidator();
    }

    [Fact]
    public void Validate_InvalidName_ShouldReturnError()
    {
        // Arrange
        var client = new ClientCreateUpdateDTO { Name = "Jo", Email = "valid@example.com" };

        // Act
        var result = _clientValidator.Validate(client);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(ClientErrors.InvalidNameSize, result.Error);
    }

    [Fact]
    public void Validate_EmptyName_ShouldReturnError()
    {
        // Arrange
        var client = new ClientCreateUpdateDTO { Name = "", Email = "valid@example.com" };

        // Act
        var result = _clientValidator.Validate(client);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(ClientErrors.InvalidNameSize, result.Error);
    }

    [Fact]
    public void Validate_InvalidEmail_ShouldReturnError()
    {
        // Arrange
        var client = new ClientCreateUpdateDTO { Name = "Valid Name", Email = "invalidEmail" };

        // Act
        var result = _clientValidator.Validate(client);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(CommomErrors.Email.InvalidEmail(client.Email), result.Error);
    }

    [Fact]
    public void Validate_EmptyEmail_ShouldReturnError()
    {
        // Arrange
        var client = new ClientCreateUpdateDTO { Name = "Valid Name", Email = "" };

        // Act
        var result = _clientValidator.Validate(client);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(CommomErrors.Email.InvalidEmail(client.Email), result.Error);
    }

    [Fact]
    public void Validate_ValidClient_ShouldReturnSuccess()
    {
        // Arrange
        var client = new ClientCreateUpdateDTO { Name = "Valid Name", Email = "valid@example.com" };

        // Act
        var result = _clientValidator.Validate(client);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(client, result.Value);
    }
}
