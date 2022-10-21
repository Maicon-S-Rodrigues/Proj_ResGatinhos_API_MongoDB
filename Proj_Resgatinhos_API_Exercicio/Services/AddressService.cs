using MongoDB.Driver;
using Proj_Resgatinhos_API_Exercicio.Models;
using Proj_Resgatinhos_API_Exercicio.Utils;
using System.Collections.Generic;

namespace Proj_Resgatinhos_API_Exercicio.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;
        public AddressService(IDataBaseSettings settings)
        {
            var address = new MongoClient(settings.ConnectionString);
            var database = address.GetDatabase(settings.DataBaseName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);
        }

        public Address Create(Address address)
        {
            _address.InsertOne(address);
            return address;
        }

        public List<Address> Get() => _address.Find<Address>(address => true).ToList();


        public Address Get(string id) => _address.Find<Address>(address => address.Id == id).FirstOrDefault();


        public void Update(string id, Address addressIn)
        {
            _address.ReplaceOne(address => address.Id == id, addressIn);
            Get(addressIn.Id);
        }


        public void Remove(Address addressIn) => _address.DeleteOne(address => address.Id == addressIn.Id);
    }
}
