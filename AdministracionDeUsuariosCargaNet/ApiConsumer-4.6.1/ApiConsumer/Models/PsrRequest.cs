using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer.Models
{
    
    public class PsrRequest
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string pin { get; set; }
        public string asignado { get; set; }
    }
}
