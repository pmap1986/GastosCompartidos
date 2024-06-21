using ApiGastosCSena.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiGastosCSena.Data
{
    public class LoginData
    {
        public static List<Usuario> loginData(Login oLogin) {

                List<Usuario> oListaUsuario = new List<Usuario>();
                ConexionBD objEst = new ConexionBD();
                string sentencia;
                sentencia = "EXECUTE SP_LOGIN '" + oLogin.Email + "','" + oLogin.password + "'";

                if (!objEst.Consultar(sentencia, false))
                {

                    objEst = null;
                    return oListaUsuario;
                }
                else
                {
                    SqlDataReader dr = objEst.Reader;
                    while (dr.Read())
                    {
                        Console.WriteLine(dr);
                        oListaUsuario.Add(new Usuario()
                        {
                            Id_usuario = dr["id_usuario"].ToString(),
                            nombre = dr["nombre"].ToString(),
                            celular = dr["celular"].ToString(),
                            email = dr["email"].ToString(),
                            fechaIngreso = Convert.ToDateTime(dr["fechaIngreso"].ToString())
                        });

                    }

                    return oListaUsuario;
                   
                }
            
        }

        

        

    }
}