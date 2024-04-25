using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personaapi_dotnet.DAO;
using personaapi_dotnet.Models;

namespace personaapi_dotnet.Controllers
{
    public class ProfesionesController : Controller
    {
        private readonly IProfesionDAO _profesionDAO;

        public ProfesionesController(IProfesionDAO profesionDAO)
        {
            _profesionDAO = profesionDAO;
        }

        // GET: Profesiones
        public async Task<IActionResult> Index()
        {
            return View(await _profesionDAO.GetAllProfesiones());
        }

        // GET: Profesiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesion = await _profesionDAO.GetProfesionById(id.Value);
            if (profesion == null)
            {
                return NotFound();
            }

            return View(profesion);
        }

        // GET: Profesiones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesiones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] Profesion profesion)
        {
            if (ModelState.IsValid)
            {
                await _profesionDAO.AddProfesion(profesion);
                return RedirectToAction(nameof(Index));
            }
            return View(profesion);
        }

        // GET: Profesiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesion = await _profesionDAO.GetProfesionById(id.Value);
            if (profesion == null)
            {
                return NotFound();
            }
            return View(profesion);
        }

        // POST: Profesiones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] Profesion profesion)
        {
            if (id != profesion.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _profesionDAO.UpdateProfesion(profesion);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _profesionDAO.ProfesionExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(profesion);
        }

        // GET: Profesiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesion = await _profesionDAO.GetProfesionById(id.Value);
            if (profesion == null)
            {
                return NotFound();
            }

            return View(profesion);
        }

        // POST: Profesiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _profesionDAO.DeleteProfesion(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
