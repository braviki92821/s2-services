﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using s2_services.Models.S2;
using System.ComponentModel.DataAnnotations;

namespace s2_services.models
{
    public class Spic
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        private DateTime FechaCaptura;
        [Required]
        public string ejercicioFiscal { get; set; }
        public string rfc { get ; set; }
        public string curp { get; set; }
        [Required]
        public string nombres { get; set; }
        [Required]
        public string primerApellido { get; set; }
        [Required]
        public string segundoApellido { get; set; }
        [Required]
        public ramo ramo { get; set; }
        [Required]
        public Genero genero { get; set; }
        [Required]
        public institucionDependencia institucionDependencia { get; set; }
        [Required]
        public puesto puesto { get; set; }
        public List<tipoArea> tipoArea { get; set; }
        public List<nivelResponsabilidad> nivelResponsabilidad { get; set; }
        public List<tipoProcedimiento> tipoProcedimiento { get; set; }
        public superiorInmediato superiorInmediato { get; set; }
        public string observaciones { get; set; }

        public Spic(){ }

        public DateTime fechaCaptura { get => FechaCaptura; set => FechaCaptura = new DateTime(value.Ticks, DateTimeKind.Utc); }
    }
}
