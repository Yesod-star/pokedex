using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokeApi.Models;

public record Type
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; } = null!;

}