namespace ApiAddressSearchBackEnd.Models
{
    public class MongoDbConfiguration
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CepsCollectionName { get; set; } = null!;
    }
}
