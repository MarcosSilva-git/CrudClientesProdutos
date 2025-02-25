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
    public void GetPaged_ShouldReturnProducts()
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
            .Setup(repo => repo.GetPaged(1, 1))
            .Returns(pagedEntity);

        // Act
        var result = _productService.GetPaged(1, 1);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Items);
    }

    [Fact]
    public void Create_WithValidProduct_ShouldReturnProduct()
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
            .Create(It.IsAny<ProductEntity>()))
            .Returns(productEntity);

        // Act
        var result = _productService.Create(productDto);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(productDto.Name, result.Value!.Name);
    }

    [Fact]
    public void Create_WithInvalidPrice_ShouldReturnError()
    {
        // Arrange
        var productDto = new ProductCreateUpdateDTO { Name = "Smartphone", Price = 0, Stock = 20 };
        _productValidator.Setup(validator => validator.Validate(productDto)).Returns(ProductErrors.InvalidPrice);

        // Act
        var result = _productService.Create(productDto);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(ProductErrors.InvalidPrice, result.Error);
    }

    [Fact]
    public void Update_WithValidProduct_ShouldReturnUpdatedProduct()
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

        _productRepository.Setup(repo => repo.Find(1)).Returns(existingProduct);
        _productRepository.Setup(repo => repo.Update(It.IsAny<ProductEntity>())).Returns(existingProduct);

        // Act
        var result = _productService.UpdateAsync(1, updatedProductDto);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(updatedProductDto.Name, result.Value!.Name);
    }

    [Fact]
    public void Update_WithNonExistentProduct_ShouldReturnNotFound()
    {
        // Arrange
        var updatedProductDto = new ProductCreateUpdateDTO { Name = "Tablet Pro", Price = 700, Stock = 12 };

        _productRepository
            .Setup(repo => repo.Find(1))
            .Returns((ProductEntity?)null);

        _productValidator
            .Setup(validator => validator.Validate(updatedProductDto))
            .Returns(Result<ProductCreateUpdateDTO, Error>.Success(updatedProductDto));

        // Act
        var result = _productService.UpdateAsync(1, updatedProductDto);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(ProductErrors.NotFound, result.Error);
    }

    [Fact]
    public void Delete_WithValidId_ShouldReturnDeletedId()
    {
        // Arrange
        _productRepository.Setup(repo => repo.Delete(1)).Returns(1);

        // Act
        var result = _productService.Delete(1);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(1, result.Value);
    }

    [Fact]
    public void Delete_WithInvalidId_ShouldReturnError()
    {
        // Act
        var result = _productService.Delete(0);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(ProductErrors.InvalidId(0), result.Error);
    }
}
