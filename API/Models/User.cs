using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models;

public class User
{
    [BsonId]
    [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("firstname"), BsonRepresentation(BsonType.String)]
    public string? FirstName { get; set; }
    [BsonElement("lastname"), BsonRepresentation(BsonType.String)]
    public string? LastName { get; set; }
    [BsonElement("email"), BsonRepresentation(BsonType.String)]
    public string? Email { get; set; }
    [BsonElement("title"), BsonRepresentation(BsonType.String)]
    public string? Title { get; set; }
}