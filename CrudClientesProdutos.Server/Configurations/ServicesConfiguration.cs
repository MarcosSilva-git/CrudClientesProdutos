using CrudClientesProdutos.Application.Client;
using CrudClientesProdutos.Application.Product;

namespace CrudClientesProdutos.Server.Configurations;

internal static class ServicesConfiguration
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductValidator, ProductValidator>();

        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IClientValidator, ClientValidator>();
    }
}
