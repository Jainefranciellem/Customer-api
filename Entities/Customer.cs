using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities
{
    public class Customer
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("first_name"), BsonRepresentation(BsonType.String)]
        public string FirstName { get; set; }
        [BsonElement("last_name"), BsonRepresentation(BsonType.String)]
        public string LastName { get; set; }
        [BsonElement("email"), BsonRepresentation(BsonType.String)]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}