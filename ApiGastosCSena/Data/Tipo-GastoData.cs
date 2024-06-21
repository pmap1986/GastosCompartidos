using ApiGastosCSena.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiGastosCSena.Data
{
    public class Tipo_GastoData
    {
        public static List<Tipo_Gasto> Listar()
        {
            List<Tipo_Gasto> oListaTipo_Gasto = new List<Tipo_Gasto>();

            try
            {
                ConexionBD objEst = new ConexionBD();
                string sentencia;
                sentencia = "EXECUTE SP_LISTAR_TIPO_GASTO";

                if (objEst.Consultar(sentencia, false))
                {
                    SqlDataReader dr = objEst.Reader;
                    while (dr.Read())
                    {
                        oListaTipo_Gasto.Add(new Tipo_Gasto()
                        {
                            IdG = Convert.ToInt32(dr["IdG"]),
                            Tipo = dr["tipo"].ToString()
                            
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar el error (puedes registrar el error, lanzar una excepción personalizada, etc.)
                // Aquí se está simplemente registrando el error en la consola
                Console.WriteLine("Error en el método Listar: " + ex.Message);
            }

            return oListaTipo_Gasto;
        }
    }
}