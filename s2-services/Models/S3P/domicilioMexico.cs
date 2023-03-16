namespace s2_services.Models.S3P
{
    public class domicilioMexico
    {
        public pais pais { get; set; }
        public entidadFederativa entidadFederativa { get; set; }
        public municipio municipio { get; set; }
        public string codigoPostal { get; set; }
        public localidad localidad { get; set; }
        public vialidad vialidad { get; set; }
        public string numeroExterior { get; set; }
        public string numeroInterior { get; set; }
    }
}
