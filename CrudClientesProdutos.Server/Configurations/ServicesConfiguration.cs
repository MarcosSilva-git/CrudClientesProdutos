using Microsoft.AspNetCore.Mvc;
using CrudClientesProdutos.Application.Interfaces;
using CrudClientesProdutos.Application.Services;

namespace CrudClientesProdutos.Server.Configurations;

public static class ServicesConfiguration
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IClientService, ClientService>();
    }
}
