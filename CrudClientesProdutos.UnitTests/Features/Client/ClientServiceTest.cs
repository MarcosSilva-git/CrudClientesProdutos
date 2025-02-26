using CrudClientesProdutos.Application.Features.Client.DTO;
using CrudClientesProdutos.Application.Features.Client;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Features.Client;
using Moq;
using CrudClientesProdutos.Domain.Abstractions.Repositories;
using CrudClientesProdutos.UnitTests.Fakes;

namespace CrudClientesProdutos.UnitTests.Features.Client;

public class ClientServiceTests
{
    private readonly Mock<IPagedEntity<ClientEntity>> _pagedEntity;
    private readonly Mock<IClientRepository> _clientRepository;
    private readonly Mock<IClientValidator> _clientValidator;
    private readonly ClientService _clientService;

    public ClientServiceTests()
    {
        _pagedEntity = new Mock<IPagedEntity<ClientEntity>>();
        _clientRepository = new Mock<IClientRepository>();
        _clientValidator = new Mock<IClientValidator>();
        _clientService = new ClientService(_clientRepository.Object, _clientValidator.Object);
    }

    [Fact]
    public async Task GetPagedAsync_ShouldReturnClients()
    {
        // Arrange
        var clients = new List<ClientEntity> 
        { 
            new ClientEntity("john Doe", "john@example.com", null, true)
        };

        var pagedEntity = new FakePagedEntity<ClientEntity>
        {
            Items = clients,
            TotalItems = 1,
            Page = 1,
            PageSize = 1,
            TotalPages = 1
        };

        _clientRepository.Setup(repo => repo.GetPagedAsync(1, 1))
            .ReturnsAsync(pagedEntity);

        // Act
        var result = await _clientService.GetPagedAsync(1, 1);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Items);
    }

    [Fact]
    public async Task CreateAsync_InvalidName_ShouldReturnError()
    {
        // Arrange
        var client = new ClientCreateUpdateDTO { Name = "Jo", Email = "valid@example.com" };

        _clientValidator
            .Setup(validator => validator.Validate(client))
            .Returns(ClientErrors.InvalidNameSize);

        // Act
        var result = await _clientService.CreateAsync(client);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(ClientErrors.InvalidNameSize, result.Error);
    }

    [Fact]
    public async Task CreateAsync_InvalidEmail_ShouldReturnError()
    {
        // Arrange
        var client = new ClientCreateUpdateDTO { Name = "Valid Name", Email = "invalidEmail" };

        _clientValidator
            .Setup(validator => validator.Validate(client))
            .Returns(CommomErrors.Email.InvalidEmail(client.Email));

        // Act
        var result = await _clientService.CreateAsync(client);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(CommomErrors.Email.InvalidEmail(client.Email), result.Error);
    }

    [Fact]
    public async Task CreateAsync_ValidClient_ShouldCallRepositoryAndReturnEntity()
    {
        // Arrange
        var clientDto = new ClientCreateUpdateDTO { Name = "Valid Name", Email = "valid@example.com" };
        var clientEntity = new ClientEntity("Valid Name", "valid@exemple.com", null, true);

        _clientValidator
            .Setup(validator => validator.Validate(clientDto))
            .Returns(clientDto);

        _clientRepository
            .Setup(repo => repo.CreateAsync(It.IsAny<ClientEntity>()))
            .ReturnsAsync(clientEntity);

        // Act
        var result = await _clientService.CreateAsync(clientDto);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(clientEntity, result.Value);
    }

    [Fact]
    public async Task UpdateAsync_ClientNotFound_ShouldReturnError()
    {
        // Arrange
        var clientDto = new ClientCreateUpdateDTO { Name = "Updated Name", Email = "updated@example.com" };

        _clientValidator
            .Setup(validator => validator.Validate(clientDto))
            .Returns(clientDto);

        _clientRepository
            .Setup(repo => repo.FindAsync(It.IsAny<long>()))
            .ReturnsAsync((ClientEntity?)null);

        // Act
        var result = await _clientService.UpdateAsync(1, clientDto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(ClientErrors.NotFound, result.Error);
    }

    [Fact]
    public async Task DeleteAsync_InvalidId_ShouldReturnError()
    {
        // Act
        var result = await _clientService.DeleteAsync(0);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(ClientErrors.InvalidId(0), result.Error);
    }

    [Fact]
    public async Task DeleteAsync_ClientNotFound_ShouldReturnError()
    {
        // Arrange
        _clientRepository
            .Setup(repo => repo.DeleteAsync(It.IsAny<long>()))
            .ReturnsAsync((long?)null);

        // Act
        var result = await _clientService.DeleteAsync(1);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(ClientErrors.NotFound, result.Error);
    }
}
