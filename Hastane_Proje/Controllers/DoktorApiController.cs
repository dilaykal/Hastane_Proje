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
    public class DoktorApiController : ControllerBase
    {
        private readonly HastaneContext _context = new HastaneContext();


        // GET: api/DoktorApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doktor>>> GetDoktorlar()
        {
          if (_context.Doktorlar == null)
          {
              return NotFound();
          }
            return await _context.Doktorlar.ToListAsync();
        }

        // GET: api/DoktorApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doktor>> GetDoktor(int id)
        {
          if (_context.Doktorlar == null)
          {
              return NotFound();
          }
            var doktor = await _context.Doktorlar.FindAsync(id);

            if (doktor == null)
            {
                return NotFound();
            }

            return doktor;
        }

        // PUT: api/DoktorApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoktor(int id, Doktor doktor)
        {
            if (id != doktor.DoktorID)
            {
                return BadRequest();
            }

            _context.Entry(doktor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoktorExists(id))
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

        [HttpGet]
        [Route("GetDoctorsByPoliklinik/{id}")]
        public ActionResult<IEnumerable<Doktor>> GetDoctorsByPoliklinik(int id)
        {
            var doktorlar = _context.Doktorlar.Where(d => d.Poliklinik.PoliklinikID == id).ToList();
            return Ok(doktorlar);
        }

        // POST: api/DoktorApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doktor>> PostDoktor(Doktor doktor)
        {
          if (_context.Doktorlar == null)
          {
              return Problem("Entity set 'HastaneContext.Doktorlar'  is null.");
          }
            _context.Doktorlar.Add(doktor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoktor", new { id = doktor.DoktorID }, doktor);
        }

        // DELETE: api/DoktorApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoktor(int id)
        {
            if (_context.Doktorlar == null)
            {
                return NotFound();
            }
            var doktor = await _context.Doktorlar.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }

            _context.Doktorlar.Remove(doktor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoktorExists(int id)
        {
            return (_context.Doktorlar?.Any(e => e.DoktorID == id)).GetValueOrDefault();
        }
    }
}
