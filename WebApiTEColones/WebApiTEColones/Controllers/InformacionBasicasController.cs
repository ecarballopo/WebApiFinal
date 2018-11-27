using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiTEColones;

namespace WebApiTEColones.Controllers
{
    public class InformacionBasicasController : ApiController
    {
        private TEColonesEntities db = new TEColonesEntities();

        // GET: api/InformacionBasicas
        public IQueryable<InformacionBasica> GetInformacionBasicas()
        {
            return db.InformacionBasicas;
        }

        // GET: api/InformacionBasicas/5
        [ResponseType(typeof(InformacionBasica))]
        public async Task<IHttpActionResult> GetInformacionBasica(int id)
        {
            InformacionBasica informacionBasica = await db.InformacionBasicas.FindAsync(id);
            if (informacionBasica == null)
            {
                return NotFound();
            }

            return Ok(informacionBasica);
        }

        // PUT: api/InformacionBasicas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInformacionBasica(int id, InformacionBasica informacionBasica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != informacionBasica.IdInformacionBasica)
            {
                return BadRequest();
            }

            db.Entry(informacionBasica).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformacionBasicaExists(id))
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

        // POST: api/InformacionBasicas
        [ResponseType(typeof(InformacionBasica))]
        public async Task<IHttpActionResult> PostInformacionBasica(InformacionBasica informacionBasica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InformacionBasicas.Add(informacionBasica);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = informacionBasica.IdInformacionBasica }, informacionBasica);
        }

        // DELETE: api/InformacionBasicas/5
        [ResponseType(typeof(InformacionBasica))]
        public async Task<IHttpActionResult> DeleteInformacionBasica(int id)
        {
            InformacionBasica informacionBasica = await db.InformacionBasicas.FindAsync(id);
            if (informacionBasica == null)
            {
                return NotFound();
            }

            db.InformacionBasicas.Remove(informacionBasica);
            await db.SaveChangesAsync();

            return Ok(informacionBasica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InformacionBasicaExists(int id)
        {
            return db.InformacionBasicas.Count(e => e.IdInformacionBasica == id) > 0;
        }
    }
}