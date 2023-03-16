namespace s2_services.Models.S2
{
    public class superiorInmediato
    {
        public string nombres { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string curp { get; set; }
        public string rfc { get; set; }
        public superiorInmediatoPuesto puesto { get; set; }

        public superiorInmediato() { }

    }
}
