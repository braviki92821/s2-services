using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace s2_services.Models
{
    public class tokenBson
    {
        [BsonId]
        private ObjectId id;
        [BsonElement]
        private string access_token;
        [BsonElement]
        private string token_type;
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        private DateTime expires_in;
        [BsonElement]
        private string refresh_token;
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        private DateTime refresh_token_expires_in;
        [BsonElement]
        private string username;
        [BsonElement]
        private string[] scope;

        public ObjectId Id { get => id; set => id = value; }
        public string Access_token { get => access_token; set => access_token = value; }
        public string Token_type { get => token_type; set => token_type = value; }
        public DateTime Expires_in { get => expires_in; set => expires_in = new DateTime(value.Ticks,DateTimeKind.Utc); }
        public string Refresh_token { get => refresh_token; set => refresh_token = value; }
        public DateTime Refresh_token_expires_in { get => refresh_token_expires_in; set => new DateTime(value.Ticks, DateTimeKind.Utc); }
        public string Username { get => username; set => username = value; }
        public string[] Scope { get => scope; set => scope = value; }
    }
}
