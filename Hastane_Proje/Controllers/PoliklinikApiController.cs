using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hastane_Proje.Models;

namespace Hastane_Proje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliklinikApiController : ControllerBase
    {
        private readonly HastaneContext _context = new HastaneContext();

        // GET: api/PoliklinikApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poliklinik>>> GetPoliklinikler()
        {
          if (_context.Poliklinikler == null)
          {
              return NotFound();
          }
            return await _context.Poliklinikler.ToListAsync();
        }

        // GET: api/PoliklinikApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poliklinik>> GetPoliklinik(int id)
        {
          if (_context.Poliklinikler == null)
          {
              return NotFound();
          }
            var poliklinik = await _context.Poliklinikler.FindAsync(id);

            if (poliklinik == null)
            {
                return NotFound();
            }

            return poliklinik;
        }

        // PUT: api/PoliklinikApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoliklinik(int id, Poliklinik poliklinik)
        {
            if (id != poliklinik.PoliklinikID)
            {
                return BadRequest();
            }

            _context.Entry(poliklinik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliklinikExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PoliklinikApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Poliklinik>> PostPoliklinik(Poliklinik poliklinik)
        {
          if (_context.Poliklinikler == null)
          {
              return Problem("Entity set 'HastaneContext.Poliklinikler'  is null.");
          }
            _context.Poliklinikler.Add(poliklinik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoliklinik", new { id = poliklinik.PoliklinikID }, poliklinik);
        }

        // DELETE: api/PoliklinikApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoliklinik(int id)
        {
            if (_context.Poliklinikler == null)
            {
                return NotFound();
            }
            var poliklinik = await _context.Poliklinikler.FindAsync(id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            _context.Poliklinikler.Remove(poliklinik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoliklinikExists(int id)
        {
            return (_context.Poliklinikler?.Any(e => e.PoliklinikID == id)).GetValueOrDefault();
        }
    }
}
