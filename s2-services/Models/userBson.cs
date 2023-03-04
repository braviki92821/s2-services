using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace s2_services.models
{
    public class userBson
    {
        [BsonId]
        private ObjectId id;
        [BsonElement]
        private string username;
        [BsonElement]
        private string nombres;
        [BsonElement]
        private string apellidoPaterno;
        [BsonElement]
        private string apellidoMaterno;
        [BsonElement]
        private string email;
        [BsonElement]
        private string dependencia;
        [BsonElement]
        private string password;
        [BsonElement]
        private string[] scope;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public ObjectId Id { get => id; set => id = value; }
        public string[] Scope { get => scope; set => scope = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public string Email { get => email; set => email = value; }
        public string Dependencia { get => dependencia; set => dependencia = value; }

    }
}
