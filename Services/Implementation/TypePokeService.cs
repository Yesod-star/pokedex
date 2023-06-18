using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokeApi.Models;

namespace PokeApi.Services;

public class TypePokeService : iTypePokeService
{
    private readonly IMongoCollection<Models.Type> _pokemonCollection;

    public TypePokeService(
        IOptions<PokemonDatabaseSettings> pokemonDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            pokemonDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            pokemonDatabaseSettings.Value.DatabaseName);

        _pokemonCollection = mongoDatabase.GetCollection<Models.Type>(
            "type");
    }

    public async Task<List<Models.Type>> GetAsync() =>
        await _pokemonCollection.Find(_ => true).ToListAsync();

    public async Task<Models.Type?> GetAsync(Guid id) =>
        await _pokemonCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Models.Type newType) =>
        await _pokemonCollection.InsertOneAsync(newType);

    public async Task UpdateAsync(Guid id, Models.Type updatedType) =>
        await _pokemonCollection.ReplaceOneAsync(x => x.Id == id, updatedType);

    public async Task RemoveAsync(Guid id) =>
        await _pokemonCollection.DeleteOneAsync(x => x.Id == id);
}