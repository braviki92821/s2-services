using System.ComponentModel.DataAnnotations;

namespace s2_services.Models.filtro
{
    public class user
    {
        private string username;
        private string password;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
