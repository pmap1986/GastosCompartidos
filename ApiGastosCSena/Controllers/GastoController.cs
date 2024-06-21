using ApiGastosCSena.Data;
using ApiGastosCSena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiGastosCSena.Controllers
{
    public class GastoController : ApiController
    {

        // Nuevo método GET: Imprimir Hello World
        // GET api/gastos/hello
        [HttpGet]
        [Route("api/gasto/hello")]
        public IHttpActionResult GetHelloWorld()
        {
            return Ok("Hello World");
        }

        [HttpGet]
        [Route("api/gasto/lista/{id_u}")]
        public List<Gasto> GetByUser(string id_u)
        {
            try
            {
                return GastoData.Listar(id_u);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // GET api/<controller>/5
        public List<Gasto> Get(string id)
        {
            return GastoData.consultar(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Gasto oGasto)
        {
            return GastoData.registarGasto(oGasto);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Gasto oGasto)
        {
            return GastoData.actualizarGasto(oGasto);
        }

        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return GastoData.eliminarGasto(id);
        }
    }
}