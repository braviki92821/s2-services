using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using s2_services.models;
using s2_services.Models;
using s2_services.Models.filtro;
using s2_services.Services.conexiones;

namespace s2_services.Services
{
    public class ssancionadosService
    {
        private readonly IMongoCollection<Ssancionados> ssancionadosColl;

        public ssancionadosService(IOptions<S3SConnection> mongoconnection)
        {
            var mongoClient = new MongoClient(mongoconnection.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoconnection.Value.DataBaseName);
            ssancionadosColl = mongoDatabase.GetCollection<Ssancionados>(mongoconnection.Value.S3SCollectionName);
        }

        public async Task<List<Ssancionados>> GetSsancionados()
        {
            return ssancionadosColl.FindAsync(new BsonDocument()).Result.ToList();
        }

        public Ssancionados insertar(Ssancionados ssancionados) {
            ssancionadosColl.InsertOne(ssancionados);
            return ssancionados;
        }

        public List<Ssancionados> GetSsancionadosbynames(ssancionadosFilter ssancionadosFilter)
        {
            string search = "{'institucionDependencia.nombre':/" + ssancionadosFilter.institucionDependencia +"/i,'servidorPublicoSancionado.nombres':/" + ssancionadosFilter.nombres+ "/i,'servidorPublicoSancionado.primerApellido':/" + ssancionadosFilter.primerApellido+ "/i,'servidorPublicoSancionado.segundoApellido':/" + ssancionadosFilter.segundoApellido+ "/i,tipoSancion:{$elemMatch:{valor:/" + ssancionadosFilter.tipoSancion+"/i}}}";
            var filter = Builders<Ssancionados>.Filter;
            var filterDefinition = filter.Or(search);
            return ssancionadosColl.FindAsync(filterDefinition).Result.ToList();
        }

        public async Task agregarVarios(List<Ssancionados> ssancionados)
        {
            await ssancionadosColl.InsertManyAsync(ssancionados);
        }

        public async Task actualizarSpS(Ssancionados ssancionados)
        {
            var filter = Builders<Ssancionados>.Filter.Eq(s => s.id, ssancionados.id);
            await ssancionadosColl.ReplaceOneAsync(filter, ssancionados);
        }

    }
}
