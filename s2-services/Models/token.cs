using MongoDB.Bson.Serialization.Attributes;

namespace s2_services.Models
{
    public class token
    {
        private string access_token;
        private string token_type;
        private DateTime expires_in;
        private string refresh_token;
        private DateTime refresh_token_expires_in;
        private string username;
        private string[] scope;

        public string Access_token { get => access_token; set => access_token = value; }
        public string Token_type { get => token_type; set => token_type = value; }
        public DateTime Expires_in { get => expires_in; set => expires_in = value; }
        public string Refresh_token { get => refresh_token; set => refresh_token = value; }
        public DateTime Refresh_token_expires_in { get => refresh_token_expires_in; set => refresh_token_expires_in = value; }
        public string Username { get => username; set => username = value; }
        public string[] Scope { get => scope; set => scope = value; }
    }
}
