using MongoDB.Driver;
using s2_services.models;

namespace s2_services.repository
{
    public class MongoConnectionAuth
    {

        public MongoClient client;
        public IMongoDatabase auth;


        public MongoConnectionAuth()
        {
            client = new MongoClient("mongodb://localhost:27017");
            auth = client.GetDatabase("auth20");
        }
    
    }
}
