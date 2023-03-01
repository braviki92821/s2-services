using MongoDB.Driver;

namespace s2_services.repository
{
    public class MongoConnection
    {
        public string ConnectionString { get; set; } = null!;
        public string DataBaseName { get; set; } = null!;
        public string S2CollectionName { get; set; } = null!;
    }
}
