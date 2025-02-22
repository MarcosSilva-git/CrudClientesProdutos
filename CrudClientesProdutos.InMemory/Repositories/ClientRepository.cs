using CrudClientesProdutos.Domain.Entities;
using CrudClientesProdutos.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrudClientesProdutos.InMemory.Repositories;

public class ClientRepository(InMemoryDbContext context) : IClientRepository
{
    private readonly InMemoryDbContext _context = context;

    public async Task<IEnumerable<ClientEntity>> GetAllAsync()
        => await _context.Client.ToListAsync();
}
