using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTEColones.Controllers
{
    public class TEColonesBeneficioController : ApiController
    {
        private TEColonesEntities db = new TEColonesEntities();

        // GET: api/TEColonesBeneficio
        [HttpGet]
        public IHttpActionResult GetTEColonesBeneficio()
        {
            return Ok(db.FilaApilada());
        }
    }
}
