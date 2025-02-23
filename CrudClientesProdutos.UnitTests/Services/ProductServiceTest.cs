using CrudClientesProdutos.Application.Product;
using CrudClientesProdutos.Application.Product.DTO;
using CrudClientesProdutos.Domain.Client;
using CrudClientesProdutos.Domain.Product;
using CrudClientesProdutos.Domain.Products;
using Moq;

namespace CrudClientesProdutos.UnitTests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _productRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnProducts()
        {
            // Arrange
            var products = new List<ProductEntity> { new ProductEntity { Id = 1, Name = "Laptop", Price = 1200, Stock = 10 } };
            _productRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);

            // Act
            var result = await _productService.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task CreateAsync_WithValidProduct_ShouldReturnProduct()
        {
            // Arrange
            var productDto = new ProductCreateUpdateDTO { Name = "Smartphone", Price = 800, Stock = 20 };
            var productEntity = new ProductEntity { Name = "Smartphone", Price = 800, Stock = 20 };

            _productRepository
                .Setup(repo => repo.CreateAsync(It.IsAny<ProductEntity>()))
                .ReturnsAsync(productEntity);

            // Act
            var result = await _productService.CreateAsync(productDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(productDto.Name, result.Value!.Name);
        }

        [Fact]
        public async Task CreateAsync_WithInvalidPrice_ShouldReturnError()
        {
            // Arrange
            var productDto = new ProductCreateUpdateDTO { Name = "Smartphone", Price = 0, Stock = 20 };

            // Act
            var result = await _productService.CreateAsync(productDto);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ProductErrors.InvalidPrice, result.Error);
        }

        [Fact]
        public async Task UpdateAsync_WithValidProduct_ShouldReturnUpdatedProduct()
        {
            // Arrange
            var existingProduct = new ProductEntity { Id = 1, Name = "Tablet", Price = 600, Stock = 15 };
            var updatedProductDto = new ProductCreateUpdateDTO { Name = "Tablet Pro", Price = 700, Stock = 12 };

            _productRepository.Setup(repo => repo.FindAsync(1)).ReturnsAsync(existingProduct);
            _productRepository.Setup(repo => repo.UpdateAsync(It.IsAny<ProductEntity>())).ReturnsAsync(existingProduct);

            // Act
            var result = await _productService.UpdateAsync(1, updatedProductDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(updatedProductDto.Name, result.Value!.Name);
        }

        [Fact]
        public async Task UpdateAsync_WithNonExistentProduct_ShouldReturnNotFound()
        {
            // Arrange
            _productRepository.Setup(repo => repo.FindAsync(1)).ReturnsAsync((ProductEntity?)null);

            var updatedProductDto = new ProductCreateUpdateDTO { Name = "Tablet Pro", Price = 700, Stock = 12 };

            // Act
            var result = await _productService.UpdateAsync(1, updatedProductDto);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ProductErrors.NotFound, result.Error);
        }

        [Fact]
        public async Task DeleteAsync_WithValidId_ShouldReturnDeletedId()
        {
            // Arrange
            _productRepository.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync(1);

            // Act
            var result = await _productService.DeleteAsync(1);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.Value);
        }

        [Fact]
        public async Task DeleteAsync_WithInvalidId_ShouldReturnError()
        {
            // Act
            var result = await _productService.DeleteAsync(0);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ClientErrors.InvalidId(0), result.Error);
        }
    }

}
