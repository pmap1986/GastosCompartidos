using ApiGastosCSena.Data;
using ApiGastosCSena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiGastosCSena.Controllers
{
    public class LoginController : ApiController
    {
        // POST api/<controller>
        public List<Usuario> Post([FromBody] Login oLogin)
        {
            return LoginData.loginData(oLogin);
        }
    }
}