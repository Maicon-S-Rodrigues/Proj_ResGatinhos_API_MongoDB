using MongoDB.Bson.Serialization.Attributes;

namespace Proj_Resgatinhos_API_Exercicio.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
    }
}
