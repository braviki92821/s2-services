using MongoDB.Driver;

namespace s2_services.Services.conexiones
{
    public class S2Connection
    {
        public string ConnectionString { get; set; } = null!;
        public string DataBaseName { get; set; } = null!;
        public string S2CollectionName { get; set; } = null!;
    }
}
