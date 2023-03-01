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
            if (spic.Nombres==null)
            {

            }
            spicColl.InsertOne(spic);
            return spic;
        }

            
    }
}
