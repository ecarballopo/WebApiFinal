using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTEColones.Models
{
    //Clase que recibe las credenciales de los clientes
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}