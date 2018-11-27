using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiTEColones;

namespace WebApiTEColones.Controllers
{
    public class SedeXTECsController : ApiController
    {
        private TEColonesEntities db = new TEColonesEntities();

        // GET: api/SedeXTECs
        public IQueryable<SedeXTEC> GetSedeXTECs()
        {
            return db.SedeXTECs;
        }

        // GET: api/SedeXTECs/5
        [ResponseType(typeof(SedeXTEC))]
        public IHttpActionResult GetSedeXTEC(int id)
        {
            SedeXTEC sedeXTEC = db.SedeXTECs.Find(id);
            if (sedeXTEC == null)
            {
                return NotFound();
            }

            return Ok(sedeXTEC);
        }

        // PUT: api/SedeXTECs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSedeXTEC(int id, SedeXTEC sedeXTEC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sedeXTEC.IdSedeXTEC)
            {
                return BadRequest();
            }

            db.Entry(sedeXTEC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SedeXTECExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SedeXTECs
        [ResponseType(typeof(SedeXTEC))]
        public IHttpActionResult PostSedeXTEC(SedeXTEC sedeXTEC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SedeXTECs.Add(sedeXTEC);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sedeXTEC.IdSedeXTEC }, sedeXTEC);
        }

        // DELETE: api/SedeXTECs/5
        [ResponseType(typeof(SedeXTEC))]
        public IHttpActionResult DeleteSedeXTEC(int id)
        {
            SedeXTEC sedeXTEC = db.SedeXTECs.Find(id);
            if (sedeXTEC == null)
            {
                return NotFound();
            }

            db.SedeXTECs.Remove(sedeXTEC);
            db.SaveChanges();

            return Ok(sedeXTEC);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SedeXTECExists(int id)
        {
            return db.SedeXTECs.Count(e => e.IdSedeXTEC == id) > 0;
        }
    }
}