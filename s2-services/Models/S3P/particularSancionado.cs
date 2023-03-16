namespace s2_services.Models.S3P
{
    public class particularSancionado
    {
        public string nombreRazonSocial { get; set; }
        public string objetoSocial { get; set; }
        public string rfc { get; set; }
        public string tipoPersona { get; set; }
        public string telefono { get; set; }
        public domicilioMexico domicilioMexico { get; set; }
        public domicilioExtranjero domicilioExtranjero { get; set; }
    }
}
