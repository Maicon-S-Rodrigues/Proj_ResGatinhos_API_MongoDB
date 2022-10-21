using MongoDB.Driver;
using Proj_Resgatinhos_API_Exercicio.Models;
using Proj_Resgatinhos_API_Exercicio.Utils;
using System.Collections.Generic;

namespace Proj_Resgatinhos_API_Exercicio.Services
{
    public class PersonService
    {
        private readonly IMongoCollection<Person> _person;

        public PersonService(IDataBaseSettings settings)
        {
            var person = new MongoClient(settings.ConnectionString);
            var database = person.GetDatabase(settings.DataBaseName);
            _person = database.GetCollection<Person>(settings.PersonCollectionName);
        }

        public Person Create(Person person)
        {
            _person.InsertOne(person);
            return person;
        }


        public List<Person> Get() => _person.Find<Person>(person => true).ToList();


        public Person Get(string id) => _person.Find<Person>(person => person.Id == id).FirstOrDefault();


        public void Update(Person personIn, string id)
        {
            _person.ReplaceOne(person => person.Id == id, personIn);
        }


        public void Remove(Person personIn) => _person.DeleteOne(client => client.Id == personIn.Id);
    }
}
