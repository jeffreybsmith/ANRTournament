using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using ANRTournament.Models;

namespace ANRTournament.Controllers
{
    [Produces("application/json")]
    [Route("api/Identities")]
    public class IdentitiesController : Controller
    {
        private ANRTournamentContext _context;

        public IdentitiesController(ANRTournamentContext context)
        {
            _context = context;
        }

        // GET: api/Identities
        [HttpGet]
        public IEnumerable<Identity> GetIdentities()
        {
            return _context.Identities;
        }

        // GET: api/Identities/5
        [HttpGet("{id}", Name = "GetIdentity")]
        public async Task<IActionResult> GetIdentity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Identity identity = await _context.Identities.SingleAsync(m => m.Id == id);

            if (identity == null)
            {
                return HttpNotFound();
            }

            return Ok(identity);
        }

        // PUT: api/Identities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentity([FromRoute] int id, [FromBody] Identity identity)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != identity.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(identity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentityExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/Identities
        [HttpPost]
        public async Task<IActionResult> PostIdentity([FromBody] Identity identity)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Identities.Add(identity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IdentityExists(identity.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetIdentity", new { id = identity.Id }, identity);
        }

        // DELETE: api/Identities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdentity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Identity identity = await _context.Identities.SingleAsync(m => m.Id == id);
            if (identity == null)
            {
                return HttpNotFound();
            }

            _context.Identities.Remove(identity);
            await _context.SaveChangesAsync();

            return Ok(identity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IdentityExists(int id)
        {
            return _context.Identities.Count(e => e.Id == id) > 0;
        }
    }
}