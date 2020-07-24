using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer.Models.Psr
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Pcr
    {
        public bool estado { get; set; }
        public List<object> emailCaminantes { get; set; }
        public string _id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string pin { get; set; }
        public string asignado { get; set; }
        public int __v { get; set; }

    }

    public class ListadoPsrResponse
    {
        public int conteo { get; set; }
        public bool ok { get; set; }
        public List<Pcr> pcr { get; set; }

    }


}
