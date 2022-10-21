using MongoDB.Driver;
using Proj_Resgatinhos_API_Exercicio.Models;
using Proj_Resgatinhos_API_Exercicio.Utils;
using System.Collections.Generic;

namespace Proj_Resgatinhos_API_Exercicio.Services
{
    public class PetService
    {
        private readonly IMongoCollection<Pet> _pet;

        public PetService(IDataBaseSettings settings)
        {
            var pet = new MongoClient(settings.ConnectionString);
            var database = pet.GetDatabase(settings.DataBaseName);
            _pet = database.GetCollection<Pet>(settings.PetCollectionName);
        }


        public Pet Create(Pet pet)
        {
            _pet.InsertOne(pet);
            return pet;
        }


        public List<Pet> Get() => _pet.Find<Pet>(pet => true).ToList();


        public Pet Get(string id) => _pet.Find<Pet>(pet => pet.Id == id).FirstOrDefault();

        public void Update(Pet petIn, string id)
        {
            _pet.ReplaceOne(pet => pet.Id == id, petIn);
        }


        public void Remove(Pet petIn) => _pet.DeleteOne(pet => pet.Id == petIn.Id);
    }
}
