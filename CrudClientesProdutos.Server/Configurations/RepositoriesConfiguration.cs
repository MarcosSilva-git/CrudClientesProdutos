using CrudClientesProdutos.Domain.Clients;
using CrudClientesProdutos.Domain.Products;
using CrudClientesProdutos.InMemory.Repositories;

namespace CrudClientesProdutos.Server.Configurations;

public static class RepositoriesConfiguration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
    }
}
