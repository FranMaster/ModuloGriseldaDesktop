using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer.Models.login
{
    public class Usuario
    {
        public string role { get; set; }
        public bool estado { get; set; }
        public bool google { get; set; }
        public string _id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public int __v { get; set; }

    }

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

    public class Data
    {
        public Usuario usuario { get; set; }
        public Pcr pcr { get; set; }

    }

    public class LoginResponse
    {
        public bool ok { get; set; }
        public Data data { get; set; }
        public string token { get; set; }

    }


}
