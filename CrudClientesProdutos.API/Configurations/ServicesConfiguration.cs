using CrudClientesProdutos.Application.Features.Client;
using CrudClientesProdutos.Application.Features.Product;
using CrudClientesProdutos.Domain.Features.Client;
using CrudClientesProdutos.Domain.Features.Product;
using CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB.Features.Client;
using CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB.Features.Product;

namespace CrudClientesProdutos.Server.Configurations;

internal static class ServicesConfiguration
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddEntitiesBasedServices(services);
    }

    private static void AddEntitiesBasedServices(IServiceCollection services)
    {
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IClientValidator, ClientValidator>();
        services.AddScoped<IClientRepository, ClientRepository>();

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductValidator, ProductValidator>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
