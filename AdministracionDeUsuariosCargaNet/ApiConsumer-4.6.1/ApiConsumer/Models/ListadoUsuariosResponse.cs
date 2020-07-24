using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer.Models.Listado
{
    public class Usuario
    {
        public string role { get; set; }
        public bool estado { get; set; }
        public bool google { get; set; }
        public string _id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }

    }

    public class ListadoUsuariosResponse
    {
        public int conteo { get; set; }
        public bool ok { get; set; }
        public List<Usuario> usuario { get; set; }

    }
}
