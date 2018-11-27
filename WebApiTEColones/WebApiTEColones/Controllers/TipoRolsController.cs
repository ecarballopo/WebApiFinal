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
    public class TipoRolsController : ApiController
    {
        private TEColonesEntities db = new TEColonesEntities();

        // GET: api/TipoRols
        public IQueryable<TipoRol> GetTipoRols()
        {
            return db.TipoRols;
        }

        // GET: api/TipoRols/5
        [ResponseType(typeof(TipoRol))]
        public async Task<IHttpActionResult> GetTipoRol(int id)
        {
            TipoRol tipoRol = await db.TipoRols.FindAsync(id);
            if (tipoRol == null)
            {
                return NotFound();
            }

            return Ok(tipoRol);
        }

        // PUT: api/TipoRols/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipoRol(int id, TipoRol tipoRol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoRol.IdTipoRol)
            {
                return BadRequest();
            }

            db.Entry(tipoRol).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoRolExists(id))
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

        // POST: api/TipoRols
        [ResponseType(typeof(TipoRol))]
        public async Task<IHttpActionResult> PostTipoRol(TipoRol tipoRol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoRols.Add(tipoRol);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipoRol.IdTipoRol }, tipoRol);
        }

        // DELETE: api/TipoRols/5
        [ResponseType(typeof(TipoRol))]
        public async Task<IHttpActionResult> DeleteTipoRol(int id)
        {
            TipoRol tipoRol = await db.TipoRols.FindAsync(id);
            if (tipoRol == null)
            {
                return NotFound();
            }

            db.TipoRols.Remove(tipoRol);
            await db.SaveChangesAsync();

            return Ok(tipoRol);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoRolExists(int id)
        {
            return db.TipoRols.Count(e => e.IdTipoRol == id) > 0;
        }
    }
}