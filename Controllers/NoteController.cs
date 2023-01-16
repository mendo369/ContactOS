using Microsoft.AspNetCore.Mvc;

using AppContactos.Models;
using AppContactos.Servicios.Contrato;

using System.Security.Claims;

namespace AppContactos.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        public IActionResult GetAllNotes()
        {
            return View();
        }

        public IActionResult SaveNote()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveNote(Note note)
        {
            ClaimsPrincipal ClaimUser = HttpContext.User;
            string UserID = "";

            if (ClaimUser.Identity.IsAuthenticated)
            {
                UserID = ClaimUser.Claims.Where(c => c.Type == ClaimTypes.SerialNumber)
                         .Select(c => c.Value).SingleOrDefault();
            }

            note.IdUser = Convert.ToInt32(UserID);
                
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
