using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using s2_services.models;
using s2_services.Models.filtro;
using s2_services.Services.conexiones;

namespace s2_services.repository
{
    public class spicService
    {
        private readonly IMongoCollection<Spic> spicColl;

        public spicService(IOptions<S2Connection> mongoconnection)
        {
            var mongoClient = new MongoClient(mongoconnection.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoconnection.Value.DataBaseName);
            spicColl = mongoDatabase.GetCollection<Spic>(mongoconnection.Value.S2CollectionName);
        }

        public async Task<List<Spic>> GetSpicList()
        {
            return spicColl.FindAsync(new BsonDocument()).Result.ToList();
        }

        public Spic agregar(Spic spic)
        {
            spicColl.InsertOne(spic);
            return spic;
        }

        public List<Spic> GetSpCbynames(spicFilter spicFilter)
        {
            string search = "{nombres:/"+spicFilter.nombres+"/i,primerApellido:/"+spicFilter.primerApellido+ "/i,segundoApellido:/"+spicFilter.segundoApellido+ "/i,'institucionDependencia.nombre':/" + spicFilter.institucionDependencia + "/i,tipoProcedimiento:{$elemMatch:{valor:/"+spicFilter.procedimiento+"/i}}}";
            var filter = Builders<Spic>.Filter;
            var filterDefinition = filter.Or(search);
            return spicColl.FindAsync(filterDefinition).Result.ToList();
        }

        public async Task agregarVarios(List<Spic> spics)
        {
             await spicColl.InsertManyAsync(spics);
        }

        public async Task actualizarSp(Spic spic)
        {
            var filter = Builders<Spic>.Filter.Eq(s=>s.id,spic.id);
            await spicColl.ReplaceOneAsync(filter,spic);
        }
    }
}
