using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGastosCSena.Models
{
    public class Gasto
    {
        public string Id_gasto { get; set; }
        public string Nombre_Gasto { get; set; }
        public int valor_total { get; set; }
        public int n_integrantes { get; set; }
        public int n_cuotas { get; set; }        
        public string tipo { get; set; }
        public string Nombre_Usuario {  get; set; } 
        public DateTime fechaCreacion { get; set; }
    }
}