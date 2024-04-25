using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personaapi_dotnet.DAO;
using personaapi_dotnet.Models;

namespace personaapi_dotnet.Controllers
{
    public class TelefonosController : Controller
    {
        private readonly ITelefonoDAO _telefonoDAO;

        public TelefonosController(ITelefonoDAO telefonoDAO)
        {
            _telefonoDAO = telefonoDAO;
        }

        // GET: Telefonos
        public async Task<IActionResult> Index()
        {
            var telefonos = await _telefonoDAO.GetAllTelefonos();
            return View(telefonos);
        }

        // GET: Telefonos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _telefonoDAO.GetTelefonoById(id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // GET: Telefonos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Telefonos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Numero,Operador,PersonaCedula")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _telefonoDAO.AddTelefono(telefono);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    // Maneja el error de violación de clave duplicada.
                    if (ex.InnerException?.Message.Contains("PK_Telefonos") == true)
                    {
                        ModelState.AddModelError("Numero", "El número de teléfono ya existe.");
                    }
                }
            }
            return View(telefono);
        }

        // GET: Telefonos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _telefonoDAO.GetTelefonoById(id);
            if (telefono == null)
            {
                return NotFound();
            }
            return View(telefono);
        }

        // POST: Telefonos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Numero,Operador,PersonaCedula")] Telefono telefono)
        {
            if (id != telefono.Numero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _telefonoDAO.UpdateTelefono(telefono);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _telefonoDAO.TelefonoExists(telefono.Numero))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(telefono);
        }

        // GET: Telefonos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _telefonoDAO.GetTelefonoById(id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // POST: Telefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _telefonoDAO.DeleteTelefono(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
