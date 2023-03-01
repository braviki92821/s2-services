using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using s2_services.models;

namespace s2_services.repository
{
    public class userService
    {
        private readonly IMongoCollection<users> usersColl;

        public userService(IOptions<MongoConnectionAuth> mongoconnection) { 
            var mongoClient=new MongoClient(mongoconnection.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoconnection.Value.DataBaseName);
            usersColl = mongoDatabase.GetCollection<users>(mongoconnection.Value.UsersCollectionName);
        }

        public async Task<users> GetUsuario(string nombre,string password)
        {
            var filter = Builders<users>.Filter;
            var filterDefinition=filter.And(filter.StringIn("username",nombre),filter.StringIn("password",password));
            return await usersColl.FindAsync(filterDefinition).Result.FirstOrDefaultAsync();
        }
    }
}
