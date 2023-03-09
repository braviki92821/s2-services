using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace s2_services.models
{
    public class Spic
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string id;
        private DateTime fechaCaptura;
        private string ejercicioFiscal;
        private string rfc;
        private string curp;
        private string nombres;
        private string primerApellido;
        private string segundoApellido;
        private ramo ramo;
        private Genero genero;
        private institucionDependencia institucionDependencia;
        private puesto puesto;
        private List<tipoArea> tipoArea;
        private List<nivelResponsabilidad> nivelResponsabilidad;
        private List<tipoProcedimiento> tipoProcedimiento;
        private superiorInmediato superiorInmediato;
        private string observaciones; 

        public Spic(){ }

        public string Id { get => id; set => id = value; }
        [Required]
        public DateTime FechaCaptura { get => fechaCaptura; set => fechaCaptura = new DateTime(value.Ticks, DateTimeKind.Utc); }
        [Required]
        public string EjercicioFiscal { get => ejercicioFiscal; set => ejercicioFiscal = value; }
        public string Rfc { get => rfc; set => rfc = value; }
        public string Curp { get => curp; set => curp = value; }
        [Required]
        public string Nombres { get => nombres; set => nombres = value; }
        [Required]
        public string PrimerApellido { get => primerApellido; set => primerApellido = value; }
        [Required]
        public string SegundoApellido { get => segundoApellido; set => segundoApellido = value; }
        [Required]
        public ramo Ramo { get => ramo; set => ramo = value; }
        [Required]
        public Genero Genero { get => genero; set => genero = value; }
        [Required]
        public institucionDependencia InstitucionDependencia { get => institucionDependencia; set => institucionDependencia = value; }
        [Required]
        public puesto Puesto { get => puesto; set => puesto = value; }
        [Required]
        public List<tipoArea> TipoArea { get => tipoArea; set => tipoArea = value; }
        [Required]
        public List<nivelResponsabilidad> NivelResponsabilidad { get => nivelResponsabilidad; set => nivelResponsabilidad = value; }
        [Required]
        public List<tipoProcedimiento> TipoProcedimiento { get => tipoProcedimiento; set => tipoProcedimiento = value; }
        [Required]
        public superiorInmediato SuperiorInmediato { get => superiorInmediato; set => superiorInmediato = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }

    }
}
