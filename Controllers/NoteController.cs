using Microsoft.AspNetCore.Mvc;

using AppContactos.Models;
using AppContactos.Servicios.Contrato;

namespace AppContactos.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        public IActionResult SaveNote()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveNote(Note note)
        {
            bool noteCreated = await _noteService.SaveNote(note);

            if (noteCreated)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["Mensaje"] = "Error. Por favor intente de nuevo";

            return View();
        }
        
        public IActionResult DetailsNote()
        {
            return View();
        }
    }
}
