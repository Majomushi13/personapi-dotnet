using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using personaapi_dotnet.Context;
using personaapi_dotnet.Models;

namespace personaapi_dotnet.DAO
{
    public class TelefonoDAO : ITelefonoDAO
    {
        private readonly AppDbContext _context;

        public TelefonoDAO(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Telefono>> GetAllTelefonos()
        {
            return await _context.Telefonos.ToListAsync();
        }

        public async Task<Telefono> GetTelefonoById(string id)
        {
            return await _context.Telefonos.FindAsync(id);
        }

        public async Task AddTelefono(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTelefono(Telefono telefono)
        {
            _context.Update(telefono);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTelefono(string id)
        {
            var telefono = await GetTelefonoById(id);
            if (telefono != null)
            {
                _context.Telefonos.Remove(telefono);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> TelefonoExists(string id)
        {
            return await _context.Telefonos.AnyAsync(e => e.Numero == id);
        }
    }
}
