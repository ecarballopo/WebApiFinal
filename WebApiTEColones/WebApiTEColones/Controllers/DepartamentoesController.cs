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
    public class DepartamentoesController : ApiController
    {
        private TEColonesEntities db = new TEColonesEntities();

        // GET: api/Departamentoes
        public IQueryable<Departamento> GetDepartamentoes()
        {
            return db.Departamentoes;
        }

        // GET: api/Departamentoes/5
        [ResponseType(typeof(Departamento))]
        public async Task<IHttpActionResult> GetDepartamento(int id)
        {
            Departamento departamento = await db.Departamentoes.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            return Ok(departamento);
        }

        // PUT: api/Departamentoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDepartamento(int id, Departamento departamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departamento.IdDepartamento)
            {
                return BadRequest();
            }

            db.Entry(departamento).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(id))
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

        // POST: api/Departamentoes
        [ResponseType(typeof(Departamento))]
        public async Task<IHttpActionResult> PostDepartamento(Departamento departamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Departamentoes.Add(departamento);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = departamento.IdDepartamento }, departamento);
        }

        // DELETE: api/Departamentoes/5
        [ResponseType(typeof(Departamento))]
        public async Task<IHttpActionResult> DeleteDepartamento(int id)
        {
            Departamento departamento = await db.Departamentoes.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            db.Departamentoes.Remove(departamento);
            await db.SaveChangesAsync();

            return Ok(departamento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartamentoExists(int id)
        {
            return db.Departamentoes.Count(e => e.IdDepartamento == id) > 0;
        }
    }
}