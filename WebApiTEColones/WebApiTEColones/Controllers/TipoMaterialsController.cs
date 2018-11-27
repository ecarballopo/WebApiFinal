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
    public class TipoMaterialsController : ApiController
    {
        private TEColonesEntities db = new TEColonesEntities();

        // GET: api/TipoMaterials
        public IQueryable<TipoMaterial> GetTipoMaterials()
        {
            return db.TipoMaterials;
        }

        // GET: api/TipoMaterials/5
        [ResponseType(typeof(TipoMaterial))]
        public async Task<IHttpActionResult> GetTipoMaterial(int id)
        {
            TipoMaterial tipoMaterial = await db.TipoMaterials.FindAsync(id);
            if (tipoMaterial == null)
            {
                return NotFound();
            }
            return Ok(tipoMaterial);
        }

        // PUT: api/TipoMaterials/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipoMaterial(int id, TipoMaterial tipoMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoMaterial.IdTipoMaterial)
            {
                return BadRequest();
            }

            db.Entry(tipoMaterial).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoMaterialExists(id))
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

        // POST: api/TipoMaterials
        [ResponseType(typeof(TipoMaterial))]
        public async Task<IHttpActionResult> PostTipoMaterial(TipoMaterial tipoMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoMaterials.Add(tipoMaterial);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipoMaterial.IdTipoMaterial }, tipoMaterial);
        }

        // DELETE: api/TipoMaterials/5
        [ResponseType(typeof(TipoMaterial))]
        public async Task<IHttpActionResult> DeleteTipoMaterial(int id)
        {
            TipoMaterial tipoMaterial = await db.TipoMaterials.FindAsync(id);
            if (tipoMaterial == null)
            {
                return NotFound();
            }

            db.TipoMaterials.Remove(tipoMaterial);
            await db.SaveChangesAsync();

            return Ok(tipoMaterial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoMaterialExists(int id)
        {
            return db.TipoMaterials.Count(e => e.IdTipoMaterial == id) > 0;
        }
    }
}