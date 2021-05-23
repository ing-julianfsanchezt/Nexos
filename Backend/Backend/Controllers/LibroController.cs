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
    public class LibroController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public LibroController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Libro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibro()
        {
            return await _context.Libro.ToListAsync();
        }

        // GET: api/Libro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
            var libro = await _context.Libro.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        // PUT: api/Libro/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            if (id != libro.IdLibro)
            {
                return BadRequest();
            }

            _context.Entry(libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
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

        // POST: api/Libro
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            var editorial = _context.Editorial.Find(libro.IdEditorial);
            bool existeEditorial = editorial != null ? true : false;
            bool existeAutor = _context.Autor.Find(libro.IdAutor) != null ? true : false;
            
            if (existeAutor)
            {
                if (existeEditorial)
                {
                    int countBooks = _context.Libro.Count(t => t.Editorial.IdEditorial == libro.IdEditorial); //Conteo de libros registrados en una editorial especifica
                    if (editorial.MaxLibrosRegistrados == -1 || countBooks <= editorial.MaxLibrosRegistrados)
                    {
                        _context.Libro.Add(libro);
                        await _context.SaveChangesAsync();
                        return CreatedAtAction("GetLibro", new { id = libro.IdLibro }, libro);
                    }
                    else
                    {
                        return StatusCode(417, "No es posible registrar el libro, se alcanzó el máximo permitido.");
                    }
                }
                else
                {
                    return StatusCode(417, "La editorial no está registrada.");
                }
            }
            else
            {
                return StatusCode(417, "El autor no está registrado.");
            }
        }


        // DELETE: api/Libro/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Libro>> DeleteLibro(int id)
        {
            var libro = await _context.Libro.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            _context.Libro.Remove(libro);
            await _context.SaveChangesAsync();

            return libro;
        }

        private bool LibroExists(int id)
        {
            return _context.Libro.Any(e => e.IdLibro == id);
        }
    }
}
