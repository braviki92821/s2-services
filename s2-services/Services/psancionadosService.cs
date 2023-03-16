using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using s2_services.Models;
using s2_services.Services.conexiones;

namespace s2_services.Services
{
    public class psancionadosService
    {
        private readonly IMongoCollection<Psancionados> psancionadosColl;

        public psancionadosService(IOptions<S3PConnection> mongoconnection)
        {
            var mongoClient = new MongoClient(mongoconnection.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoconnection.Value.DataBaseName);
            psancionadosColl = mongoDatabase.GetCollection<Psancionados>(mongoconnection.Value.S3PCollectionName);
        }

        public async Task<List<Psancionados>> GetSsancionados()
        {
            return psancionadosColl.FindAsync(new BsonDocument()).Result.ToList();
        }
    }
}
