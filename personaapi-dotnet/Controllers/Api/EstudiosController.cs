using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personaapi_dotnet.Context;
using personaapi_dotnet.Models;

namespace personaapi_dotnet.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstudiosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Estudios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudio>>> GetEstudios()
        {
            return await _context.Estudios.ToListAsync();
        }

        // GET: api/Estudios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudio>> GetEstudio(int id)
        {
            var estudio = await _context.Estudios.FindAsync(id);

            if (estudio == null)
            {
                return NotFound();
            }

            return estudio;
        }

        // PUT: api/Estudios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudio(int id, Estudio estudio)
        {
            if (id != estudio.Id)
            {
                return BadRequest();
            }

            _context.Entry(estudio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudioExists(id))
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

        // POST: api/Estudios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estudio>> PostEstudio(Estudio estudio)
        {
            _context.Estudios.Add(estudio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudio", new { id = estudio.Id }, estudio);
        }

        // DELETE: api/Estudios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudio(int id)
        {
            var estudio = await _context.Estudios.FindAsync(id);
            if (estudio == null)
            {
                return NotFound();
            }

            _context.Estudios.Remove(estudio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudioExists(int id)
        {
            return _context.Estudios.Any(e => e.Id == id);
        }
    }
}
