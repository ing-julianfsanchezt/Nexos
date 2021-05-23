using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public EditorialController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Editorial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editorial>>> GetEditorial()
        {
            return await _context.Editorial.ToListAsync();
        }

        // GET: api/Editorial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Editorial>> GetEditorial(int id)
        {
            var editorial = await _context.Editorial.FindAsync(id);

            if (editorial == null)
            {
                return NotFound();
            }

            return editorial;
        }

        // PUT: api/Editorial/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditorial(int id, Editorial editorial)
        {
            if (id != editorial.IdEditorial)
            {
                return BadRequest();
            }

            _context.Entry(editorial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditorialExists(id))
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

        // POST: api/Editorial
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Editorial>> PostEditorial(Editorial editorial)
        {
            _context.Editorial.Add(editorial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEditorial", new { id = editorial.IdEditorial }, editorial);
        }

        // DELETE: api/Editorial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Editorial>> DeleteEditorial(int id)
        {
            var editorial = await _context.Editorial.FindAsync(id);
            if (editorial == null)
            {
                return NotFound();
            }

            _context.Editorial.Remove(editorial);
            await _context.SaveChangesAsync();

            return editorial;
        }

        private bool EditorialExists(int id)
        {
            return _context.Editorial.Any(e => e.IdEditorial == id);
        }
    }
}
