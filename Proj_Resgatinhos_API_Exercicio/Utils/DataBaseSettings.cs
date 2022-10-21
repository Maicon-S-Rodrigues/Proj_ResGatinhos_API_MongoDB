namespace Proj_Resgatinhos_API_Exercicio.Utils
{
    public class DataBaseSettings : IDataBaseSettings
    {
        public string PetCollectionName { get; set; }
        public string PersonCollectionName { get; set; }
        public string AddressCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
    }
}
