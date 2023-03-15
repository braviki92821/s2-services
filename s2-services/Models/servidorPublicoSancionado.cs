using s2_services.models;

namespace s2_services.Models
{
    public class servidorPublicoSancionado
    {
        public Genero genero { get; set; }
        public string nombres { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string rfc { get; set; }
        public string curp { get; set; }
        public string puesto { get; set; }
        public string nivel { get; set; }

    }
}
