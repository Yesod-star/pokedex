using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokeApi.Models;

namespace PokeApi.Services;

public class PokeService : iPokeService
{
    private readonly IMongoCollection<Pokemon> _pokemonCollection;

    public PokeService(
        IOptions<PokemonDatabaseSettings> pokemonDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            pokemonDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            pokemonDatabaseSettings.Value.DatabaseName);

        _pokemonCollection = mongoDatabase.GetCollection<Pokemon>(
            "pokemon");
    }

    public async Task<List<Pokemon>> GetAsync() =>
        await _pokemonCollection.Find(_ => true).ToListAsync();

    public async Task<Pokemon?> GetAsync(Guid id) =>
        await _pokemonCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Pokemon newPokemon) =>
        await _pokemonCollection.InsertOneAsync(newPokemon);

    public async Task UpdateAsync(Guid id, Pokemon updatedPokemon) =>
        await _pokemonCollection.ReplaceOneAsync(x => x.Id == id, updatedPokemon);

    public async Task RemoveAsync(Guid id) =>
        await _pokemonCollection.DeleteOneAsync(x => x.Id == id);
}