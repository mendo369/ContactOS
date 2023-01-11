using Microsoft.AspNetCore.Mvc;

namespace AppContactos.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
