using CrudClientesProdutos.Application.Entities.Client;
using CrudClientesProdutos.Application.Entities.Product;
using CrudClientesProdutos.Domain.Entities.Client;
using CrudClientesProdutos.Domain.Entities.Product;
using CrudClientesProdutos.InMemory.Repositories;

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
