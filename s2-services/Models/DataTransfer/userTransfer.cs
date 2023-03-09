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

        [Required]
        public string Username { get => username; set => username = value; }
        [Required]
        public string Nombres { get => nombres; set => nombres = value; }
        [Required]
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        [Required]
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        [Required]
        public string Email { get => email; set => email = value; }
        [Required]
        public string Dependencia { get => dependencia; set => dependencia = value; }
        [Required]
        public string Password { get => password; set => password = value; }
        [Required]
        public string[] Scope { get => scope; set => scope = value; }
    }
}
