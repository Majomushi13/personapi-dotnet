using System.Collections.Generic;
using System.Threading.Tasks;
using personaapi_dotnet.Models;

namespace personaapi_dotnet.DAO
{
    public interface IEstudioDAO
    {
        Task<IEnumerable<Estudio>> GetAllEstudios();
        Task<Estudio> GetEstudioById(int id);
        Task AddEstudio(Estudio estudio);
        Task UpdateEstudio(Estudio estudio);
        Task DeleteEstudio(int id);
        Task<bool> EstudioExists(int id);
    }
}
