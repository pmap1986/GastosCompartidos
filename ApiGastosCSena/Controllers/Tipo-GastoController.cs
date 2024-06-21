using ApiGastosCSena.Data;
using ApiGastosCSena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiGastosCSena.Controllers
{
    public class Tipo_GastoController : ApiController
    {
        public List<Tipo_Gasto> Get()
        {
            try
            {
                return Tipo_GastoData.Listar();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}