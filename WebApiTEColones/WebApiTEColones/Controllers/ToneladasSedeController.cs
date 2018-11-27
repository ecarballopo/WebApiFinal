using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTEColones.Controllers
{
    public class ToneladasSedeController : ApiController
    {
        private TEColonesEntities db = new TEColonesEntities();


        // GET: api/TobneladasSede
        [HttpGet]
        public IHttpActionResult GetToneladasSede()
        {
            return Ok(db.ToneladasSede());
        }
    }
}
