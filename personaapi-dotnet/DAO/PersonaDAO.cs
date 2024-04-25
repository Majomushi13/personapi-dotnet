using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using personaapi_dotnet.Context;
using personaapi_dotnet.Models;

namespace personaapi_dotnet.DAO
{
    public class PersonaDAO : IPersonaDAO
    {
        private readonly AppDbContext _context;

        public PersonaDAO(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetAllPersonas()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona> GetPersonaById(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task AddPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePersona(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }
    }
}
