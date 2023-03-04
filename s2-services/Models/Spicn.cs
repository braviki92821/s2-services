using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace s2_services.models
{
    public class Spicn
    {
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


        public DateTime FechaCaptura { get => fechaCaptura; set => fechaCaptura = new DateTime(value.Ticks, DateTimeKind.Utc); }
        public string EjercicioFiscal { get => ejercicioFiscal; set => ejercicioFiscal = value; }
        public string Rfc { get => rfc; set => rfc = value; }
        public string Curp { get => curp; set => curp = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string PrimerApellido { get => primerApellido; set => primerApellido = value; }
        public string SegundoApellido { get => segundoApellido; set => segundoApellido = value; }
        public ramo Ramo { get => ramo; set => ramo = value; }
        public Genero Genero { get => genero; set => genero = value; }
        public institucionDependencia InstitucionDependencia { get => institucionDependencia; set => institucionDependencia = value; }
        public puesto Puesto { get => puesto; set => puesto = value; }
        public List<tipoArea> TipoArea { get => tipoArea; set => tipoArea = value; }
        public List<nivelResponsabilidad> NivelResponsabilidad { get => nivelResponsabilidad; set => nivelResponsabilidad = value; }
        public List<tipoProcedimiento> TipoProcedimiento { get => tipoProcedimiento; set => tipoProcedimiento = value; }
        public superiorInmediato SuperiorInmediato { get => superiorInmediato; set => superiorInmediato = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }

    }
}
