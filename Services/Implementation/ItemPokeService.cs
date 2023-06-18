using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokeApi.Models;

namespace PokeApi.Services;

public class ItemPokeService : iItemPokeService
{
    private readonly IMongoCollection<Item> _pokemonCollection;

    public ItemPokeService(
        IOptions<PokemonDatabaseSettings> pokemonDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            pokemonDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            pokemonDatabaseSettings.Value.DatabaseName);

        _pokemonCollection = mongoDatabase.GetCollection<Item>(
            "items");
    }

    public async Task<List<Item>> GetAsync() =>
        await _pokemonCollection.Find(_ => true).ToListAsync();

    public async Task<Item?> GetAsync(Guid id) =>
        await _pokemonCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Item newItem) =>
        await _pokemonCollection.InsertOneAsync(newItem);

    public async Task UpdateAsync(Guid id, Item updatedItem) =>
        await _pokemonCollection.ReplaceOneAsync(x => x.Id == id, updatedItem);

    public async Task RemoveAsync(Guid id) =>
        await _pokemonCollection.DeleteOneAsync(x => x.Id == id);
}