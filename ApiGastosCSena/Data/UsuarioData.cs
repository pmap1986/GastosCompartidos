using ApiGastosCSena.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiGastosCSena.Data
{
    public class UsuarioData
    {
        public static bool registarUsuario(Usuario oUsuario)
        {
           
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE SP_INSERTAR_USUARIO '" + oUsuario.Id_usuario + "','" + oUsuario.nombre + "','" + oUsuario.celular + "','" + oUsuario.email + "','" + oUsuario.password + "'";
            
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

        public static bool actualizarUsuario(Usuario oUsuario)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE SP_UPDATE_USUARIO '" + oUsuario.Id_usuario + "','" + oUsuario.nombre + "','" + oUsuario.celular + "','" + oUsuario.email+ "'";

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

        public static bool eliminarUsuario(string id)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE SP_ELIMINAR_USUARIO '" + id + "'"; 

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

        public static List<Usuario> Listar()
        {
            List<Usuario> oListaUsuario = new List<Usuario>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE SP_LISTAR_USUARIO";


            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read()) {
                    oListaUsuario.Add(new Usuario()
                    {
                        Id_usuario = dr["Id_Usuario"].ToString(),
                        nombre = dr["nombre"].ToString(),
                        celular = dr["celular"].ToString(),
                        email = dr["email"].ToString(),
                        fechaIngreso = Convert.ToDateTime(dr["FechaIngreso"].ToString())
                    });

                }

                return oListaUsuario;  
                
            }
            else
            {
                return oListaUsuario;
            }
            
        }

        public static List<Usuario> consultar(string id)
        {
            List<Usuario> oListaUsuario = new List<Usuario>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "EXECUTE SP_CONSULTAR_USUARIO '" + id + "'" ;

            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    Console.WriteLine(dr);
                    oListaUsuario.Add(new Usuario()
                    {
                        Id_usuario = dr["Id_Usuario"].ToString(),
                        nombre = dr["nombre"].ToString(),
                        celular = dr["celular"].ToString(),
                        email = dr["email"].ToString(),                        
                        fechaIngreso = Convert.ToDateTime(dr["fechaIngreso"].ToString())
                    });

                }

                return oListaUsuario;

            }
            else
            {
                return oListaUsuario;
            }

        }


    }
}