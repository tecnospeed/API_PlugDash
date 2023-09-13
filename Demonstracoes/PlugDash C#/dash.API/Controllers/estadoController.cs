using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dashAPI.Data;
using dashAPI.Models;

namespace dashAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class estadoController : ControllerBase
    {
        private readonly APIDbContext _context;

        public estadoController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/estado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<estado>>> Getestado()
        {
          if (_context.estado == null)
          {
              return NotFound();
          }
            return await _context.estado.ToListAsync();
        }

        // GET: api/estado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<estado>> Getestado(string id)
        {
          if (_context.estado == null)
          {
              return NotFound();
          }
            var estado = await _context.estado.FindAsync(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        // PUT: api/estado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putestado(string id, estado estado)
        {
            if (id != estado.Sigla)
            {
                return BadRequest();
            }

            _context.Entry(estado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!estadoExists(id))
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

        // POST: api/estado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<estado>> Postestado(estado estado)
        {
          if (_context.estado == null)
          {
              return Problem("Entity set 'APIDbContext.estado'  is null.");
          }
            _context.estado.Add(estado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (estadoExists(estado.Sigla))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getestado", new { id = estado.Sigla }, estado);
        }

        // DELETE: api/estado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteestado(string id)
        {
            if (_context.estado == null)
            {
                return NotFound();
            }
            var estado = await _context.estado.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            _context.estado.Remove(estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool estadoExists(string id)
        {
            return (_context.estado?.Any(e => e.Sigla == id)).GetValueOrDefault();
        }
    }
}
