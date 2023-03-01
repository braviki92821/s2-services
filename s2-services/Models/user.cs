namespace s2_services.Models
{
    public class user
    {
        private string username;
        private string password;
        private string[] scope;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string[] Scope { get => scope; set => scope = value; }
    }
}
