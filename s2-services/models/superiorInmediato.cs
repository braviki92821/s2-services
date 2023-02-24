namespace s2_services.models
{
    public class superiorInmediato
    {
        private string nombres;
        private string primerApellido;
        private string segundoApellido;
        private string curp;
        private string rfc;
        private superiorInmediatoPuesto puesto;

        public superiorInmediato() { }

        public string Nombres { get => nombres; set => nombres = value; }
        public string PrimerApellido { get => primerApellido; set => primerApellido = value; }
        public string SegundoApellido { get => segundoApellido; set => segundoApellido = value; }
        public string Curp { get => curp; set => curp = value; }
        public string Rfc { get => rfc; set => rfc = value; }
        public superiorInmediatoPuesto Puesto { get => puesto; set => puesto = value; }
    }
}
