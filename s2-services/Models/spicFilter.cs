namespace s2_services.Models
{
    public class spicFilter
    {
        private string nombres;
        private string primerApellido;
        private string segundoApellido;
        private string institucionDependencia;

        public string Nombres { get => nombres; set => nombres = value; }
        public string PrimerApellido { get => primerApellido; set => primerApellido = value; }
        public string SegundoApellido { get => segundoApellido; set => segundoApellido = value; }
        public string InstitucionDependencia { get => institucionDependencia; set => institucionDependencia = value; }
    }
}
