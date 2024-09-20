using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities
{
    public class Customer
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("first_name"), BsonRepresentation(BsonType.String)]
        public required string FirstName { get; set; }
        [BsonElement("last_name"), BsonRepresentation(BsonType.String)]
        public required string LastName { get; set; }
        [BsonElement("email"), BsonRepresentation(BsonType.String)]
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}