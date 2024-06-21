using ApiGastosCSena.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiGastosCSena.Data
{
    public class GastoData
    {
        public static bool registarGasto(Gasto oGasto)
        {

            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE SP_INSERTAR_GASTOS '" + oGasto.Id_gasto + "','" + oGasto.Nombre_Gasto + "','" + oGasto.valor_total + "','" + oGasto.n_integrantes + "','" + oGasto.n_cuotas + "','" + oGasto.Nombre_Usuario + "','" + oGasto.tipo + "'";

            if (!objEst.EjecutarSentencia(sentencia, false))
            {

                objEst = null;
                return false;
            }
            else
            {
                objEst = null;
                return true;
            }
        }

        public static bool actualizarGasto(Gasto oGasto)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE SP_UPDATE_GASTO '" + oGasto.Id_gasto + "','" + oGasto.Nombre_Gasto + "','" + oGasto.valor_total + "','"+ oGasto.n_integrantes + "','" + oGasto.n_cuotas +  "'";

            if (!objEst.EjecutarSentencia(sentencia, false))
            {

                objEst = null;
                return false;
            }
            else
            {
                objEst = null;
                return true;
            }
        }

        public static bool eliminarGasto(string id)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE SP_ELIMINAR_GASTO '" + id + "'";

            if (!objEst.EjecutarSentencia(sentencia, false))
            {

                objEst = null;
                return false;
            }
            else
            {
                objEst = null;
                return true;
            }
        }

        public static List<Gasto> Listar(String id_u)
        {
            List<Gasto> oListaGasto = new List<Gasto>();

            try
            {                
                ConexionBD objEst = new ConexionBD();
                string sentencia;
                sentencia = "EXECUTE SP_LISTAR_GASTOS '" + id_u + "'";;

                if (objEst.Consultar(sentencia, false))
                {
                    SqlDataReader dr = objEst.Reader;
                    while (dr.Read())
                    {
                        oListaGasto.Add(new Gasto()
                        {                            
                            Id_gasto = dr["Id_gasto"].ToString(),
                            Nombre_Gasto = dr["Nombre_Gasto"].ToString(),
                            valor_total = Convert.ToInt32(dr["valor_total"]),
                            n_integrantes = Convert.ToInt32(dr["n_integrantes"]),
                            n_cuotas = Convert.ToInt32(dr["n_cuotas"]),
                            tipo = dr["tipo"].ToString(),
                            Nombre_Usuario = dr["Nombre_Usuario"].ToString(),
                            fechaCreacion = Convert.ToDateTime(dr["fecha_creacion"].ToString())
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

            return oListaGasto;
        }


        public static List<Gasto> consultar(string id)
        {
            List<Gasto> oListaGasto = new List<Gasto>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE SP_CONSULTAR_GASTO '" + id + "'";

            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    Console.WriteLine(dr);
                    oListaGasto.Add(new Gasto()
                    {
                        Id_gasto = dr["Id_gasto"].ToString(),
                        Nombre_Gasto = dr["Nombre_Gasto"].ToString(),
                        valor_total = Convert.ToInt32(dr["valor_total"]),
                        n_integrantes = Convert.ToInt32(dr["n_integrantes"]),
                        n_cuotas = Convert.ToInt32(dr["n_cuotas"]),
                        tipo = dr["tipo"].ToString(),
                        Nombre_Usuario = dr["Nombre_Usuario"].ToString(),
                        fechaCreacion = Convert.ToDateTime(dr["fecha_creacion"].ToString())
                    });

                }

                return oListaGasto;

            }
            else
            {
                return oListaGasto;
            }

        }


    }
}
