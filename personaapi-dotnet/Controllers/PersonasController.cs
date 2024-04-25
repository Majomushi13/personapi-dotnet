using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using personaapi_dotnet.DAO;
using personaapi_dotnet.Models;

namespace personaapi_dotnet.Controllers
{
    public class PersonasController : Controller
    {
        private readonly IPersonaDAO _personaDAO;

        public PersonasController(IPersonaDAO personaDAO)
        {
            _personaDAO = personaDAO;
        }

        // Métodos para MVC

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var personas = await _personaDAO.GetAllPersonas();
            return View(personas);
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _personaDAO.GetPersonaById(id.Value);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cc,Nombre,Apellido,Genero,Edad")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                await _personaDAO.AddPersona(persona);
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _personaDAO.GetPersonaById(id.Value);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cc,Nombre,Apellido,Genero,Edad")] Persona persona)
        {
            if (id != persona.Cc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _personaDAO.UpdatePersona(persona);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    // Verifica si el método GetPersonaById retorna un objeto Persona o null
                    Persona Persona = await _personaDAO.GetPersonaById(id);
                    if (persona == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _personaDAO.GetPersonaById(id.Value);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _personaDAO.DeletePersona(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PersonaExists(int id)
        {
            var persona = await _personaDAO.GetPersonaById(id);
            return persona != null;
        }
    }
}
