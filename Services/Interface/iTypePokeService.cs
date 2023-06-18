using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokeApi.Models;

namespace PokeApi.Services;

public interface iTypePokeService
{
    public Task<List<Models.Type>> GetAsync();

    public Task<Models.Type?> GetAsync(Guid id);

    public Task CreateAsync(Models.Type newType);

    public Task UpdateAsync(Guid id, Models.Type updatedType);

    public Task RemoveAsync(Guid id);
}