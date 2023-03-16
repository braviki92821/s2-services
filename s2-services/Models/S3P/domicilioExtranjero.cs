namespace s2_services.Models.S3P
{
    public class domicilioExtranjero
    {
        public string calle { get; set; }
        public string numeroExterior { get; set; }
        public string numeroInterior { get; set; }
        public string ciudadLocalidad { get; set; }
        public string estadoProvincia { get; set; }
        public pais pais { get; set; }
        public string codigoPostal { get; set; }
    }
}
