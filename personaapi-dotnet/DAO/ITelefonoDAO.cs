using System.Collections.Generic;
using System.Threading.Tasks;
using personaapi_dotnet.Models;

namespace personaapi_dotnet.DAO
{
    public interface ITelefonoDAO
    {
        Task<IEnumerable<Telefono>> GetAllTelefonos();
        Task<Telefono> GetTelefonoById(string id);
        Task AddTelefono(Telefono telefono);
        Task UpdateTelefono(Telefono telefono);
        Task DeleteTelefono(string id);
        Task<bool> TelefonoExists(string id);
    }
}
