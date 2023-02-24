using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections;

namespace s2_services.models
{
    public class ramo
    {
        private int clave;
        private string valor;
 

        public ramo() { }

        public int Clave { get => clave; set => clave = value; }
        public string Valor { get => valor; set => valor = value; }

    }
}
