using System.Collections.Generic;
using System.Threading.Tasks;
using personaapi_dotnet.Models;

namespace personaapi_dotnet.DAO
{
    public interface IProfesionDAO
    {
        Task<IEnumerable<Profesion>> GetAllProfesiones();
        Task<Profesion> GetProfesionById(int id);
        Task AddProfesion(Profesion profesion);
        Task UpdateProfesion(Profesion profesion);
        Task DeleteProfesion(int id);
        Task<bool> ProfesionExists(int id);
    }
}