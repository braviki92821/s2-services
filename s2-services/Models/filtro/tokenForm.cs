namespace s2_services.Models.filtro
{
    public class tokenForm
    {
        private string token;
        private string refresh_token;
        private string username;
        private string[] scope;

        public tokenForm() { }
        public string Token { get => token; set => token = value; }
        public string Refresh_token { get => refresh_token; set => refresh_token = value; }
        public string Username { get => username; set => username = value; }
        public string[] Scope { get => scope; set => scope = value; }
    }
}
