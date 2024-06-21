using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiGastosCSena.Models
{
    public class Login
    {
        public string Email {get; set;}
        public string password {get; set;}
    }
}