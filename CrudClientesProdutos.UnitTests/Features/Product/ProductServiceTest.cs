using CrudClientesProdutos.Application.Features.Product;
using CrudClientesProdutos.Application.Features.Product.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Abstractions.Repositories;
using CrudClientesProdutos.Domain.Features.Product;
using CrudClientesProdutos.UnitTests.Fakes;
using Moq;

namespace CrudClientesProdutos.UnitTests.Features.Product;

public class ProductServiceTests
{
    private readonly Mock<IPagedEntity<ProductEntity>> _productEntity;
    private readonly Mock<IProductRepository> _productRepository;
    private readonly Mock<IProductValidator> _productValidator;
    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        _productEntity = new Mock<IPagedEntity<ProductEntity>>();
        _productRepository = new Mock<IProductRepository>();
        _productValidator = new Mock<IProductValidator>();
        _productService = new ProductService(_productRepository.Object, _productValidator.Object);
    }

    [Fact]
    public async Task GetPagedAsync_ShouldReturnProducts()
    {
        // Arrange
        var products = new List<ProductEntity> 
        { 
            new ProductEntity ("Laptop", 1200, 10) 
        };

        var pagedEntity = new FakePagedEntity<ProductEntity>
        {
            Items = products,
            TotalItems = 1,
            Page = 1,
            PageSize = 1,
            TotalPages = 1
        };

        _productRepository
            .Setup(repo => repo.GetPagedAsync(1, 1))
            .ReturnsAsync(pagedEntity);

        // Act
        var result = await _productService.GetPagedAsync(1, 1);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Items);
    }

    [Fact]
    public async Task CreateAsync_WithValidProduct_ShouldReturnProduct()
    {
        // Arrange
        var productDto = new ProductCreateUpdateDTO
        {
            Name = "Smartphone",
            Price = 800,
            Stock = 20
        };
        var productEntity = new ProductEntity("Smartphone", 800, 20);

        _productValidator.Setup(validator => validator
            .Validate(productDto))
            .Returns(Result<ProductCreateUpdateDTO, Error>.Success(productDto));

        _productRepository.Setup(repo => repo
            .CreateAsync(It.IsAny<ProductEntity>()))
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
        _productValidator.Setup(validator => validator.Validate(productDto)).Returns(ProductErrors.InvalidPrice);

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
        var existingProduct = new ProductEntity("Tablet", 600, 15);

        var updatedProductDto = new ProductCreateUpdateDTO
        {
            Name = "Tablet Pro",
            Price = 700,
            Stock = 12
        };

        _productValidator.Setup(validator => validator
            .Validate(updatedProductDto))
            .Returns(Result<ProductCreateUpdateDTO, Error>.Success(updatedProductDto));

        _productRepository.Setup(repo => repo.FindAsync(1))
            .ReturnsAsync(existingProduct);
        _productRepository.Setup(repo => repo.UpdateAsync(It.IsAny<ProductEntity>()))
            .ReturnsAsync(existingProduct);

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
        var updatedProductDto = new ProductCreateUpdateDTO { Name = "Tablet Pro", Price = 700, Stock = 12 };

        _productRepository
            .Setup(repo => repo.FindAsync(1))
            .ReturnsAsync((ProductEntity?)null);

        _productValidator
            .Setup(validator => validator.Validate(updatedProductDto))
            .Returns(Result<ProductCreateUpdateDTO, Error>.Success(updatedProductDto));

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
        Assert.Equal(ProductErrors.InvalidId(0), result.Error);
    }
}
