using CrudClientesProdutos.Domain.Interfaces;
using CrudClientesProdutos.Domain.Interfaces.Repositories;
using CrudClientesProdutos.InMemory.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;

namespace CrudClientesProdutos.Server.Configurations;

public static class RepositoriesConfiguration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
    }
}
