using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiGastosCSena
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            Console.WriteLine("gola");
            // Configuración y servicios de Web API
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            // Ruta para UsuarioController
            /*config.Routes.MapHttpRoute(
                name: "UsuarioApi",
                routeTemplate: "api/usuarios/{id}",
                defaults: new { controller = "Usuario", id = RouteParameter.Optional }
            );

            // Ruta para GastoController
            config.Routes.MapHttpRoute(
                name: "GastoApi",
                routeTemplate: "api/gastos/{id}",
                defaults: new { controller = "Gasto", id = RouteParameter.Optional }
            );*/

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
