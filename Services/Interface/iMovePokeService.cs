using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokeApi.Models;

namespace PokeApi.Services;

public interface iMovePokeService
{
    public Task<List<Move>> GetAsync();

    public Task<Move?> GetAsync(Guid id);

    public Task CreateAsync(Move newMove);

    public Task UpdateAsync(Guid id, Move updatedMove);

    public Task RemoveAsync(Guid id);
}