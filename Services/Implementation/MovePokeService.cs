using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokeApi.Models;

namespace PokeApi.Services;

public class MovePokeService : iMovePokeService
{
    private readonly IMongoCollection<Move> _pokemonCollection;

    public MovePokeService(
        IOptions<PokemonDatabaseSettings> pokemonDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            pokemonDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            pokemonDatabaseSettings.Value.DatabaseName);

        _pokemonCollection = mongoDatabase.GetCollection<Move>(
            "move");
    }

    public async Task<List<Move>> GetAsync() =>
        await _pokemonCollection.Find(_ => true).ToListAsync();

    public async Task<Move?> GetAsync(Guid id) =>
        await _pokemonCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Move newMove) =>
        await _pokemonCollection.InsertOneAsync(newMove);

    public async Task UpdateAsync(Guid id, Move updatedMove) =>
        await _pokemonCollection.ReplaceOneAsync(x => x.Id == id, updatedMove);

    public async Task RemoveAsync(Guid id) =>
        await _pokemonCollection.DeleteOneAsync(x => x.Id == id);
}