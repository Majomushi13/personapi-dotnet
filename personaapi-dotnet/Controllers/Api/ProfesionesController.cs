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
    public class ProfesionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfesionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Profesiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesion>>> GetProfesiones()
        {
            return await _context.Profesiones.ToListAsync();
        }

        // GET: api/Profesiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesion>> GetProfesion(int id)
        {
            var profesion = await _context.Profesiones.FindAsync(id);

            if (profesion == null)
            {
                return NotFound();
            }

            return profesion;
        }

        // PUT: api/Profesiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesion(int id, Profesion profesion)
        {
            if (id != profesion.Id)
            {
                return BadRequest();
            }

            _context.Entry(profesion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesionExists(id))
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

        // POST: api/Profesiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profesion>> PostProfesion(Profesion profesion)
        {
            _context.Profesiones.Add(profesion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProfesionExists(profesion.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProfesion", new { id = profesion.Id }, profesion);
        }

        // DELETE: api/Profesiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesion(int id)
        {
            var profesion = await _context.Profesiones.FindAsync(id);
            if (profesion == null)
            {
                return NotFound();
            }

            _context.Profesiones.Remove(profesion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfesionExists(int id)
        {
            return _context.Profesiones.Any(e => e.Id == id);
        }
    }
}
