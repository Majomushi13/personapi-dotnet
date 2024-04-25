using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personaapi_dotnet.DAO;
using personaapi_dotnet.Models;

namespace personaapi_dotnet.Controllers
{
    public class EstudiosController : Controller
    {
        private readonly IEstudioDAO _estudioDAO;

        public EstudiosController(IEstudioDAO estudioDAO)
        {
            _estudioDAO = estudioDAO;
        }

        // GET: Estudios
        public async Task<IActionResult> Index()
        {
            var estudios = await _estudioDAO.GetAllEstudios();
            return View(estudios);
        }

        // GET: Estudios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudio = await _estudioDAO.GetEstudioById(id.Value);
            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        // GET: Estudios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfesionId,PersonaCedula,Fecha,Universidad")] Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                await _estudioDAO.AddEstudio(estudio);
                return RedirectToAction(nameof(Index));
            }
            return View(estudio);
        }

        // GET: Estudios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudio = await _estudioDAO.GetEstudioById(id.Value);
            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        // POST: Estudios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfesionId,PersonaCedula,Fecha,Universidad")] Estudio estudio)
        {
            if (id != estudio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _estudioDAO.UpdateEstudio(estudio);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _estudioDAO.EstudioExists(estudio.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(estudio);
        }

        // GET: Estudios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudio = await _estudioDAO.GetEstudioById(id.Value);
            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        // POST: Estudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _estudioDAO.DeleteEstudio(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EstudioExists(int id)
        {
            return await _estudioDAO.EstudioExists(id);
        }
    }
}
