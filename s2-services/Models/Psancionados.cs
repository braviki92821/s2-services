using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using s2_services.models;
using s2_services.Models.S3P;

namespace s2_services.Models
{
    public class Psancionados
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        private DateTime FechaCaptura;
        public DateTime fechaCaptura { get => FechaCaptura; set => FechaCaptura = new DateTime(value.Ticks, DateTimeKind.Utc); }
        public string expediente { get; set; }
        public institucionDependencia institucionDependencia { get; set; }
        public particularSancionado particularSancionado { get; set;}
        public directorGeneral directorGeneral { get; set; }
        public apoderadoLegal apoderadoLegal { get; set; }
        public string objetoContrato { get; set; }
        public string autoridadSancionadora { get; set; }
        public string tipoFalta { get; set; }
        public List<tipoSancion> tipoSancion { get; set; }
        public string causaMotivoHechos { get; set; }
        public string acto { get; set; }
        public responsableSancion responsableSancion { get; set; }
        public string sentido { get; set; }
        public resolucion resolucion { get; set; }
        public multa multa { get; set; }
        public inhabilitacion inhabilitacion { get; set; }
        public string observaciones { get; set; }
        public List<documentos> documentos { get; set; }
    }
}
