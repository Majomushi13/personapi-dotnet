using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using personaapi_dotnet.Context;
using personaapi_dotnet.Models;

namespace personaapi_dotnet.DAO
{
    public class ProfesionDAO : IProfesionDAO
    {
        private readonly AppDbContext _context;

        public ProfesionDAO(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profesion>> GetAllProfesiones()
        {
            return await _context.Profesiones.ToListAsync();
        }

        public async Task<Profesion> GetProfesionById(int id)
        {
            return await _context.Profesiones.FindAsync(id);
        }

        public async Task AddProfesion(Profesion profesion)
        {
            _context.Profesiones.Add(profesion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfesion(Profesion profesion)
        {
            _context.Profesiones.Update(profesion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfesion(int id)
        {
            var profesion = await _context.Profesiones.FindAsync(id);
            if (profesion != null)
            {
                _context.Profesiones.Remove(profesion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ProfesionExists(int id)
        {
            return await _context.Profesiones.AnyAsync(e => e.Id == id);
        }
    }
}
