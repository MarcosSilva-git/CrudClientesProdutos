using CrudClientesProdutos.Application.Client;
using CrudClientesProdutos.Application.Product;
using CrudClientesProdutos.Domain.Client;
using CrudClientesProdutos.Domain.Product;
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
