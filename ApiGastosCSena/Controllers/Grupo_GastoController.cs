using ApiGastosCSena.Data;
using ApiGastosCSena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiGastosCSena.Controllers
{
    public class Grupo_GastoController : ApiController
    {
        public List<Grupo_Gasto> Get()
        {
            try
            {
                return Grupo_GastoData.Listar();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // GET api/<controller>/5
        public List<Grupo_Gasto> Get(string id)
        {
            return Grupo_GastoData.consultar(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Grupo_Gasto oGrupo_Gasto)
        {
            return Grupo_GastoData.registarGrupo_Gasto(oGrupo_Gasto);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Grupo_Gasto oGrupo_Gasto)
        {
            return Grupo_GastoData.actualizarGrupo_Gasto(oGrupo_Gasto);
        }

        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return Grupo_GastoData.eliminarGrupo_Gasto(id);
        }
    }
}