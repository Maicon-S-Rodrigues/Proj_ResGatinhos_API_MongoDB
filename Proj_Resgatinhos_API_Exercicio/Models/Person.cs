using MongoDB.Bson.Serialization.Attributes;

namespace Proj_Resgatinhos_API_Exercicio.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}
