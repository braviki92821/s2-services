using MongoDB.Driver;
using s2_services.models;

namespace s2_services.Services.conexiones
{
    public class AuthConnection
    {
        public string ConnectionString { get; set; } = null!;
        public string DataBaseName { get; set; } = null!;
        public string UsersCollectionName { get; set; } = null!;
        public string TokensCollectionName { get; set; } = null!;
    }
}
