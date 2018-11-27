using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTEColones.Controllers
{
    public class Top10Controller : ApiController
    {
        private TEColonesEntities db = new TEColonesEntities();

        // GET: api/Top10
        [HttpGet]
        public IHttpActionResult GetTop10()
        {
            return Ok(db.TOP10());
        }
    }
}
