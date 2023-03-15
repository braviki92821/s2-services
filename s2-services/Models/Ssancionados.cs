using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using s2_services.models;

namespace s2_services.Models
{
    public class Ssancionados
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string id;
        private institucionDependencia institucionDependencia;
        private servidorPublicoSancionado servidorPublicoSancionado;
        private tipoFalta tipoFalta;
        private resolucion resolucion;
        private multa multa;
        private inhabilitacion inhabilitacion;
        private DateTime fechaCaptura;
        private string expediente;
        private string autoridadSancionadora;
        private List<tipoSancion> tipoSancion;
        private string causaMotivoHechos;
        private string observaciones;
        private List<documentos> documentos;

        public string Id { get => id; set => id = value; }
        public institucionDependencia InstitucionDependencia { get => institucionDependencia; set => institucionDependencia = value; }
        public servidorPublicoSancionado ServidorPublicoSancionado { get => servidorPublicoSancionado; set => servidorPublicoSancionado = value; }
        public tipoFalta TipoFalta { get => tipoFalta; set => tipoFalta = value; }
        public resolucion Resolucion { get => resolucion; set => resolucion = value; }
        public multa Multa { get => multa; set => multa = value; }
        public inhabilitacion Inhabilitacion { get => inhabilitacion; set => inhabilitacion = value; }
        public DateTime FechaCaptura { get => fechaCaptura; set => fechaCaptura = value; }
        public string Expediente { get => expediente; set => expediente = value; }
        public string AutoridadSancionadora { get => autoridadSancionadora; set => autoridadSancionadora = value; }
        public List<tipoSancion> TipoSancion { get => tipoSancion; set => tipoSancion = value; }
        public string CausaMotivoHechos { get => causaMotivoHechos; set => causaMotivoHechos = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public List<documentos> Documentos { get => documentos; set => documentos = value; }
    }
}
