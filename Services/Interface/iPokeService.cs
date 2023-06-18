using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokeApi.Models;

namespace PokeApi.Services;

public interface iPokeService
{
    public Task<List<Pokemon>> GetAsync();

    public Task<Pokemon?> GetAsync(Guid id);

    public Task CreateAsync(Pokemon newPokemon);

    public Task UpdateAsync(Guid id, Pokemon updatedPoke);

    public Task RemoveAsync(Guid id);
}