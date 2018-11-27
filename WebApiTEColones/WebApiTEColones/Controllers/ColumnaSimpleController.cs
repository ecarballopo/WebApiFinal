using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTEColones.Models;

namespace WebApiTEColones.Controllers
{
    public class ColumnaSimpleController : ApiController
    {
        private TEColonesEntities db = new TEColonesEntities();

        
        // GET: api/ColumnaSimple
        [HttpGet]
        public IHttpActionResult GetColumnaSimple()
        {
            return Ok(db.ColumnaSimple());
        }
    }
}
