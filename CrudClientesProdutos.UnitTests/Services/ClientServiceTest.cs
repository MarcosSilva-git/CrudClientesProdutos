using CrudClientesProdutos.Application.Client;
using CrudClientesProdutos.Application.Client.DTO;
using CrudClientesProdutos.Domain.Client;
using Moq;

namespace CrudClientesProdutos.UnitTests.Services
{
    public class ClientServiceTests
    {
        private readonly Mock<IClientRepository> _clientRepository;
        private readonly ClientService _clientService;

        public ClientServiceTests()
        {
            _clientRepository = new Mock<IClientRepository>();
            _clientService = new ClientService(_clientRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnClients()
        {
            // Arrange
            var clients = new List<ClientEntity> { new ClientEntity { Id = 1, Name = "John Doe", Email = "john@example.com" } };
            _clientRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(clients);

            // Act
            var result = await _clientService.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task CreateAsync_InvalidName_ShouldReturnError()
        {
            // Arrange
            var client = new ClientCreateUpdateDTO { Name = "Jo", Email = "valid@example.com" };

            // Act
            var result = await _clientService.CreateAsync(client);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ClientErrors.InvalidNameSize, result);
        }

        [Fact]
        public async Task CreateAsync_InvalidEmail_ShouldReturnError()
        {
            // Arrange
            var client = new ClientCreateUpdateDTO { Name = "Valid Name", Email = "invalidEmail" };

            // Act
            var result = await _clientService.CreateAsync(client);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ClientErrors.InvalidEmail(client.Email), result);
        }

        [Fact]
        public async Task CreateAsync_ValidClient_ShouldCallRepositoryAndReturnEntity()
        {
            // Arrange
            var clientDto = new ClientCreateUpdateDTO { Name = "Valid Name", Email = "valid@example.com" };
            var clientEntity = new ClientEntity { Id = 1, Name = "Valid Name", Email = "valid@example.com" };

            _clientRepository
                .Setup(repo => repo.CreateAsync(It.IsAny<ClientEntity>()))
                .ReturnsAsync(clientEntity);

            // Act
            var result = await _clientService.CreateAsync(clientDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(clientEntity, result);
        }

        [Fact]
        public async Task UpdateAsync_ClientNotFound_ShouldReturnError()
        {
            // Arrange
            _clientRepository
                .Setup(repo => repo.FindAsync(It.IsAny<long>()))
                .ReturnsAsync((ClientEntity?)null);

            var clientDto = new ClientCreateUpdateDTO { Name = "Updated Name", Email = "updated@example.com" };

            // Act
            var result = await _clientService.UpdateAsync(1, clientDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ClientErrors.NotFound, result);
        }

        [Fact]
        public async Task DeleteAsync_InvalidId_ShouldReturnError()
        {
            // Act
            var result = await _clientService.DeleteAsync(0);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ClientErrors.InvalidId(0), result);
        }

        [Fact]
        public async Task DeleteAsync_ClientNotFound_ShouldReturnError()
        {
            // Arrange
            _clientRepository.Setup(repo => repo.DeleteAsync(It.IsAny<long>()))
                .ReturnsAsync((long?)null);

            // Act
            var result = await _clientService.DeleteAsync(1);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ClientErrors.NotFound, result.Error);
        }
    }
}
