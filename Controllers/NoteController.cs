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

        
        public IActionResult DetailsNote()
        {
            return View();
        }
    }
}
