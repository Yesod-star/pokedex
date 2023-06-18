using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokeApi.Models;

public record Item
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; } = null!;

    public decimal? Price { get; set; }

    public decimal bonus { get; set; }

    public string attribute { get; set; } = null!;
}