using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using s2_services.models;
using s2_services.repository;

namespace s2_services.Controllers
{
    [ApiController]
    [Route("oauth/user")]
    public class userController : Controller
    {
        public IConfiguration _configuration;
        internal MongoConnectionAuth connectionAuth=new MongoConnectionAuth();

        public userController(IConfiguration configuration) {
         _configuration= configuration;
        }

        [HttpGet]
        public void login(users users) {
            return connectionAuth.auth.GetCollection<users>("users").FindAsync(new BsonDocument { { "username",users.Username },{ "password",users.Password } }).Result.ToList();
        }
 
    }
}
