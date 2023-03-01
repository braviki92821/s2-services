using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace s2_services.models
{
    public class users
    {
        [BsonId]
        private ObjectId id;
        [BsonElement]
        private string username;
        [BsonElement]
        private string password;
        [BsonElement]
        private string[] scope;

        public users() { }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public ObjectId Id { get => id; set => id = value; }
        public string[] Scope { get => scope; set => scope = value; }
        //public string[] Scope { get => scope; set => scope = value; }

    }
}
