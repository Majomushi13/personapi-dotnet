using System.Collections.Generic;
using System.Threading.Tasks;
using personaapi_dotnet.Models;


namespace personaapi_dotnet.DAO
{
    public interface IPersonaDAO
    {
        Task<IEnumerable<Persona>> GetAllPersonas();
        Task<Persona> GetPersonaById(int id);
        Task AddPersona(Persona persona);
        Task UpdatePersona(Persona persona);
        Task DeletePersona(int id);
    }
}
