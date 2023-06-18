using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokeApi.Models;

public record Pokemon
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; } = null!;
    public decimal attack { get; set; }
    public decimal speed { get; set; }
    public decimal defense { get; set; }
    public virtual Type[]? type { get; set; }
    public virtual Move[]? moves { get; set; }
    public string description { get; set; } = null!;
}