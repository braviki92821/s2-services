using System.ComponentModel.DataAnnotations;

namespace s2_services.Models
{
    public class user
    {
        private string username;
        private string password;


        [Required]
        public string Username { get => username; set => username = value; }
        [Required]
        public string Password { get => password; set => password = value; }
    }
}
