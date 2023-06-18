using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokeApi.Models;

namespace PokeApi.Services;

public interface iItemPokeService
{

    public Task<List<Item>> GetAsync();

    public Task<Item?> GetAsync(Guid id);

    public Task CreateAsync(Item newItem);

    public Task UpdateAsync(Guid id, Item updatedItem);

    public Task RemoveAsync(Guid id);
}