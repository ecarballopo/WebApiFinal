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
    public class TipoBeneficiosController : ApiController
    {
        private TEColonesEntities db = new TEColonesEntities();

        // GET: api/TipoBeneficios
        public IQueryable<TipoBeneficio> GetTipoBeneficios()
        {
            return db.TipoBeneficios;
        }

        // GET: api/TipoBeneficios/5
        [ResponseType(typeof(TipoBeneficio))]
        public async Task<IHttpActionResult> GetTipoBeneficio(int id)
        {
            TipoBeneficio tipoBeneficio = await db.TipoBeneficios.FindAsync(id);
            if (tipoBeneficio == null)
            {
                return NotFound();
            }

            return Ok(tipoBeneficio);
        }

        // PUT: api/TipoBeneficios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipoBeneficio(int id, TipoBeneficio tipoBeneficio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoBeneficio.IdTipoBeneficio)
            {
                return BadRequest();
            }

            db.Entry(tipoBeneficio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoBeneficioExists(id))
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

        // POST: api/TipoBeneficios
        [ResponseType(typeof(TipoBeneficio))]
        public async Task<IHttpActionResult> PostTipoBeneficio(TipoBeneficio tipoBeneficio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoBeneficios.Add(tipoBeneficio);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipoBeneficio.IdTipoBeneficio }, tipoBeneficio);
        }

        // DELETE: api/TipoBeneficios/5
        [ResponseType(typeof(TipoBeneficio))]
        public async Task<IHttpActionResult> DeleteTipoBeneficio(int id)
        {
            TipoBeneficio tipoBeneficio = await db.TipoBeneficios.FindAsync(id);
            if (tipoBeneficio == null)
            {
                return NotFound();
            }

            db.TipoBeneficios.Remove(tipoBeneficio);
            await db.SaveChangesAsync();

            return Ok(tipoBeneficio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoBeneficioExists(int id)
        {
            return db.TipoBeneficios.Count(e => e.IdTipoBeneficio == id) > 0;
        }
    }
}