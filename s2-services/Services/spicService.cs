using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using s2_services.models;

namespace s2_services.repository
{
    public class spicService
    {
        private readonly IMongoCollection<Spic> spicColl;

        public spicService(IOptions<MongoConnection> mongoconnection)
        {
            var mongoClient = new MongoClient(mongoconnection.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoconnection.Value.DataBaseName);
            spicColl = mongoDatabase.GetCollection<Spic>(mongoconnection.Value.S2CollectionName);
        }

        public List<Spic> GetSpicList()
        {
            return spicColl.FindAsync(new BsonDocument()).Result.ToList();
        }

        public Spic agregar(Spic spic)
        {
            spicColl.InsertOne(spic);
            return spic;
        }

        public List<Spic> GetSpCbynames(string nombres,string pApellido,string sApellido,string dependencia)
        {
            string search = "{Nombres:/"+nombres+"/i,PrimerApellido:/"+pApellido+ "/i,SegundoApellido:/"+sApellido+ "/i,'InstitucionDependencia.Nombre':/"+dependencia+"/i}";
            var filter = Builders<Spic>.Filter;
            var filterDefinition = filter.Or(search);
            return spicColl.FindAsync(filterDefinition).Result.ToList();
        }


    }
}
