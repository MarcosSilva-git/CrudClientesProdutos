using CrudClientesProdutos.Domain.Client;
using CrudClientesProdutos.Domain.Product;
using CrudClientesProdutos.InMemory.Repositories;

namespace CrudClientesProdutos.Server.Configurations;

internal static class RepositoriesConfiguration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
    }
}
