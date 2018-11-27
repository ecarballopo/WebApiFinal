using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiTEColones.Models;

namespace WebApiTEColones.Controllers
{
    public class TacometroController : ApiController
    {
        private TEColonesEntities db = new TEColonesEntities();

        // GET: api/Tacometro
        [HttpGet]
        public IHttpActionResult GetTacometro()
        {
            TacometroRequest tacometroRequest = new TacometroRequest();
            tacometroRequest.Peso = db.Tacometro().First();
            return Ok(tacometroRequest);
        }
    }
}
