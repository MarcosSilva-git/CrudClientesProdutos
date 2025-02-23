using CrudClientesProdutos.Application.Services.Client;
using CrudClientesProdutos.Application.Services.Product;
using CrudClientesProdutos.Domain.Products;

namespace CrudClientesProdutos.Server.Configurations;

internal static class ServicesConfiguration
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IClientService, ClientService>();
    }
}
