using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using s2_services.models;
using s2_services.Models.S3S;

namespace s2_services.Models
{
    public class Ssancionados
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public institucionDependencia institucionDependencia { get; set; }
        public servidorPublicoSancionado servidorPublicoSancionado { get; set; }
        public tipoFalta tipoFalta { get; set; }
        public resolucion resolucion { get; set; }
        public multa multa { get; set; }
        public inhabilitacion inhabilitacion { get; set; }
        private DateTime FechaCaptura;
        public string expediente { get; set; }
        public string autoridadSancionadora { get; set; }
        public List<tipoSancion> tipoSancion { get; set; }
        public string causaMotivoHechos { get; set; }
        public string observaciones { get; set; }
        public List<documentos> documentos { get; set; }

        public DateTime fechaCaptura { get => FechaCaptura; set => FechaCaptura = new DateTime(value.Ticks, DateTimeKind.Utc); }

    }
}
