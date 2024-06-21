using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGastosCSena.Models
{
    public class Grupo_Gasto
    {
        public string Id_dg { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Nombre_Gasto { get; set; }
        public int Valor_Total { get; set;}
        public int N_integrantes { get; set; }
        public int Cuota_Persona { get; set; }
        public int Estado {  get; set; }
    }
}