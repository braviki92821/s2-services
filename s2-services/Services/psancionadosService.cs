using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using s2_services.Models;
using s2_services.Models.filtro;
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

        public async Task<List<Psancionados>> GetPsancionados()
        {
            return psancionadosColl.FindAsync(new BsonDocument()).Result.ToList();
        }

        public Psancionados insertar(Psancionados psancionados)
        {
            psancionadosColl.InsertOne(psancionados);
            return psancionados;
        }

        public List<Psancionados> GetPsancionadosbynames(psancionadosFilter psancionadosFilter)
        {
            string search = "";
            var filter = Builders<Psancionados>.Filter;
            var filterDefinition = filter.Or(search);
            return psancionadosColl.FindAsync(filterDefinition).Result.ToList();
        }

        public async Task agregarVarios(List<Psancionados> psancionados)
        {
            await psancionadosColl.InsertManyAsync(psancionados);
        }

        public async Task actualizarPs(Psancionados psancionados)
        {
            var filter = Builders<Psancionados>.Filter.Eq(s => s.id, psancionados.id);
            await psancionadosColl.ReplaceOneAsync(filter, psancionados);
        }
    }
}
