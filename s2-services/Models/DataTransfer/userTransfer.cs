using Newtonsoft.Json;
using s2_services.Data;
using System.ComponentModel.DataAnnotations;

namespace s2_services.Models.DataTransfer
{
    public class userTransfer
    {
        private string username;
        private string password;
        private string[] scope;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string[] Scope { get => scope; set => scope = value; }

    }
}
