using CrudClientesProdutos.Application.Product;
using CrudClientesProdutos.Application.Product.DTO;
using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Product;
using Moq;

namespace CrudClientesProdutos.UnitTests.Services;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _productRepository;
    private readonly Mock<IProductValidator> _productValidator;
    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        _productRepository = new Mock<IProductRepository>();
        _productValidator = new Mock<IProductValidator>();
        _productService = new ProductService(_productRepository.Object, _productValidator.Object);
    }

    [Fact]
    public void GetAll_ShouldReturnProducts()
    {
        var products = new List<ProductEntity> { new ProductEntity { Id = 1, Name = "Laptop", Price = 1200, Stock = 10 } };
        _productRepository.Setup(repo => repo.GetAll()).Returns(products);

        var result = _productService.GetAll();

        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public void Create_WithValidProduct_ShouldReturnProduct()
    {
        var productDto = new ProductCreateUpdateDTO { Name = "Smartphone", Price = 800, Stock = 20 };
        var productEntity = new ProductEntity { Name = "Smartphone", Price = 800, Stock = 20 };

        _productValidator.Setup(validator => validator
            .Validate(productDto))
            .Returns(Result<ProductCreateUpdateDTO, Error>.Success(productDto));
        _productRepository.Setup(repo => repo.Create(It.IsAny<ProductEntity>())).Returns(productEntity);

        var result = _productService.Create(productDto);

        Assert.True(result.IsSuccess);
        Assert.Equal(productDto.Name, result.Value!.Name);
    }

    [Fact]
    public void Create_WithInvalidPrice_ShouldReturnError()
    {
        var productDto = new ProductCreateUpdateDTO { Name = "Smartphone", Price = 0, Stock = 20 };
        _productValidator.Setup(validator => validator.Validate(productDto)).Returns(ProductErrors.InvalidPrice);

        var result = _productService.Create(productDto);

        Assert.True(result.IsFailure);
        Assert.Equal(ProductErrors.InvalidPrice, result.Error);
    }

    [Fact]
    public void Update_WithValidProduct_ShouldReturnUpdatedProduct()
    {
        var existingProduct = new ProductEntity { Id = 1, Name = "Tablet", Price = 600, Stock = 15 };
        var updatedProductDto = new ProductCreateUpdateDTO { Name = "Tablet Pro", Price = 700, Stock = 12 };

        _productValidator.Setup(validator => validator
            .Validate(updatedProductDto))
            .Returns(Result<ProductCreateUpdateDTO, Error>.Success(updatedProductDto));
        
        _productRepository.Setup(repo => repo.Find(1)).Returns(existingProduct);
        _productRepository.Setup(repo => repo.Update(It.IsAny<ProductEntity>())).Returns(existingProduct);

        var result = _productService.Update(1, updatedProductDto);

        Assert.True(result.IsSuccess);
        Assert.Equal(updatedProductDto.Name, result.Value!.Name);
    }

    [Fact]
    public void Update_WithNonExistentProduct_ShouldReturnNotFound()
    {
        var updatedProductDto = new ProductCreateUpdateDTO { Name = "Tablet Pro", Price = 700, Stock = 12 };
        
        _productRepository
            .Setup(repo => repo.Find(1))
            .Returns((ProductEntity?)null);

        _productValidator
            .Setup(validator => validator.Validate(updatedProductDto))
            .Returns(Result<ProductCreateUpdateDTO, Error>.Success(updatedProductDto));

        var result = _productService.Update(1, updatedProductDto);

        Assert.True(result.IsFailure);
        Assert.Equal(ProductErrors.NotFound, result.Error);
    }

    [Fact]
    public void Delete_WithValidId_ShouldReturnDeletedId()
    {
        _productRepository.Setup(repo => repo.Delete(1)).Returns(1);

        var result = _productService.Delete(1);

        Assert.True(result.IsSuccess);
        Assert.Equal(1, result.Value);
    }

    [Fact]
    public void Delete_WithInvalidId_ShouldReturnError()
    {
        var result = _productService.Delete(0);

        Assert.True(result.IsFailure);
        Assert.Equal(CommomErrors.InvalidId(0), result.Error);
    }
}
