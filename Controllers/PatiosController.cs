using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using challenger.Domain.Entities;
using challenger.Infrastructure.Context;

namespace challenger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatiosController : ControllerBase
    {
        private readonly CGContext _context;

        public PatiosController(CGContext context)
        {
            _context = context;
        }

        // GET: api/Patios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patio>>> GetPatios()
        {
            return await _context.Patios.ToListAsync();
        }

        // GET: api/Patios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patio>> GetPatio(Guid id)
        {
            var patio = await _context.Patios.FindAsync(id);

            if (patio == null)
            {
                return NotFound();
            }

            return patio;
        }

        // PUT: api/Patios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatio(Guid id, Patio patio)
        {
            if (id != patio.Id)
            {
                return BadRequest();
            }

            _context.Entry(patio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatioExists(id))
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

        // POST: api/Patios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patio>> PostPatio(Patio patio)
        {
            _context.Patios.Add(patio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatio", new { id = patio.Id }, patio);
        }

        // DELETE: api/Patios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatio(Guid id)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio == null)
            {
                return NotFound();
            }

            _context.Patios.Remove(patio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatioExists(Guid id)
        {
            return _context.Patios.Any(e => e.Id == id);
        }
    }
}
