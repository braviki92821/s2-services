using Newtonsoft.Json;
using s2_services.Data;
using System.ComponentModel.DataAnnotations;

namespace s2_services.Models.DataTransfer
{
    public class userTransfer
    {
        private string username;
        private string nombres;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private string email;
        private string dependencia;
        private string password;
        private string[] scope;

        public string Username { get => username; set => username = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public string Email { get => email; set => email = value; }
        public string Dependencia { get => dependencia; set => dependencia = value; }
        public string Password { get => password; set => password = value; }
        public string[] Scope { get => scope; set => scope = value; }
    }
}
