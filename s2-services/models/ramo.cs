using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections;

namespace s2_services.models
{
    public class ramo
    {
        public int clave { get; set; }
        public string valor { get; set; }
 

        public ramo() { }

    }
}
