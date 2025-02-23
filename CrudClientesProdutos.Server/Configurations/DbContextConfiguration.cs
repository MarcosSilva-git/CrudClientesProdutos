using CrudClientesProdutos.InMemory;
using Microsoft.EntityFrameworkCore;

namespace CrudClientesProdutos.Server.Configurations;

internal static class DbContextConfiguration
{
    public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InMemoryDbContext>(options =>
        {
            options.UseInMemoryDatabase(configuration["Database:InMemory"]!);
        });
    }
}
