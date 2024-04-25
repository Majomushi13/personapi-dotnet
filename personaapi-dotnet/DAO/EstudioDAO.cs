using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using personaapi_dotnet.Context;
using personaapi_dotnet.Models;

namespace personaapi_dotnet.DAO
{
    public class EstudioDAO : IEstudioDAO
    {
        private readonly AppDbContext _context;

        public EstudioDAO(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudio>> GetAllEstudios()
        {
            return await _context.Estudios.ToListAsync();
        }

        public async Task<Estudio> GetEstudioById(int id)
        {
            return await _context.Estudios.FindAsync(id);
        }

        public async Task AddEstudio(Estudio estudio)
        {
            _context.Estudios.Add(estudio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEstudio(Estudio estudio)
        {
            _context.Update(estudio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstudio(int id)
        {
            var estudio = await _context.Estudios.FindAsync(id);
            if (estudio != null)
            {
                _context.Estudios.Remove(estudio);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> EstudioExists(int id)
        {
            return await _context.Estudios.AnyAsync(e => e.Id == id);
        }
    }
}
