using ApiGastosCSena.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiGastosCSena.Data
{
    public class Grupo_GastoData
    {
        public static bool registarGrupo_Gasto(Grupo_Gasto oGrupo_Gasto)
        {

            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE SP_INSERTAR_GRUPO_GASTO '" + oGrupo_Gasto.Id_dg + "','" + oGrupo_Gasto.Nombre_Usuario + "','" + oGrupo_Gasto.Nombre_Gasto + "','" + oGrupo_Gasto.Valor_Total +"','" + oGrupo_Gasto.N_integrantes + "','" + oGrupo_Gasto.Cuota_Persona + "'";

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

        public static bool actualizarGrupo_Gasto(Grupo_Gasto oGrupo_Gasto)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE SP_UPDATE_GRUPO_GASTO '" + oGrupo_Gasto.Id_dg + "','" + oGrupo_Gasto.Nombre_Usuario + "','" + oGrupo_Gasto.Nombre_Gasto + "','" + oGrupo_Gasto.Valor_Total + "','" + oGrupo_Gasto.N_integrantes + "','" + oGrupo_Gasto.Cuota_Persona + "'";

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

        public static bool eliminarGrupo_Gasto(string id)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE SP_ELIMINAR_GRUPO_GASTO '" + id + "'";

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

        public static List<Grupo_Gasto> Listar()
        {
            List<Grupo_Gasto> oListaGrupo_Gasto = new List<Grupo_Gasto>();

            try
            {
                ConexionBD objEst = new ConexionBD();
                string sentencia;
                sentencia = "EXECUTE SP_LISTAR_GRUPO_GASTO";

                if (objEst.Consultar(sentencia, false))
                {
                    SqlDataReader dr = objEst.Reader;
                    while (dr.Read())
                    {
                        oListaGrupo_Gasto.Add(new Grupo_Gasto()
                        {
                            Id_dg = dr["Id_dg"].ToString(),
                            Nombre_Usuario = dr["Nombre_Usuario"].ToString(),
                            Nombre_Gasto = dr["Nombre_Gasto"].ToString(),
                            Valor_Total = Convert.ToInt32(dr["valor_total"]),
                            N_integrantes = Convert.ToInt32(dr["n_integrantes"]),
                            Cuota_Persona = Convert.ToInt32(dr["cuota_persona"]),
                            Estado = Convert.ToInt32(dr["estado"])
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

            return oListaGrupo_Gasto;
        }


        public static List<Grupo_Gasto> consultar(string id)
        {
            List<Grupo_Gasto> oListaGrupo_Gasto = new List<Grupo_Gasto>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE SP_CONSULTAR_GRUPO_GASTO '" + id + "'";

            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    Console.WriteLine(dr);
                    oListaGrupo_Gasto.Add(new Grupo_Gasto()
                    {
                        Id_dg = dr["Id_dg"].ToString(),
                        Nombre_Usuario = dr["Nombre_Usuario"].ToString(),
                        Nombre_Gasto = dr["Nombre_Gasto"].ToString(),
                        Valor_Total = Convert.ToInt32(dr["valor_total"]),
                        N_integrantes = Convert.ToInt32(dr["n_integrantes"]),
                        Cuota_Persona = Convert.ToInt32(dr["cuota_persona"]),
                        Estado = Convert.ToInt32(dr["estado"])
                    });

                }

                return oListaGrupo_Gasto;

            }
            else
            {
                return oListaGrupo_Gasto;
            }

        }
    }
}