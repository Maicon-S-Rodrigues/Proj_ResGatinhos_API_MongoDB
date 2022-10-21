namespace Proj_Resgatinhos_API_Exercicio.Utils
{
    public interface IDataBaseSettings
    {
        string PetCollectionName { get; set; }
        string PersonCollectionName { get; set; }
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DataBaseName { get; set; }
    }
}
