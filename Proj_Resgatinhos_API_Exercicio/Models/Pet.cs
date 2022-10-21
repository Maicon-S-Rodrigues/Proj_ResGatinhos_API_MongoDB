using MongoDB.Bson.Serialization.Attributes;

namespace Proj_Resgatinhos_API_Exercicio.Models
{
    public class Pet
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { set; get; }
        public string Family { get; set; }
        public string Age { set; get; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public string Status { get; set; }
        public Person Person { get; set; }
    }
}
