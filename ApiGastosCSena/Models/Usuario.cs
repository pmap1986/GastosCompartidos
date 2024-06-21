using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGastosCSena.Models
{
    public class Usuario
    {
        public string Id_usuario { get; set; }
        public string nombre { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime fechaIngreso { get; set; }

    }
}