using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokeApi.Models;

public record Move
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; } = null!;

    public decimal speed { get; set; }

    public string damage { get; set; } = null!;

    public virtual Type type { get; set; } = null!;

}