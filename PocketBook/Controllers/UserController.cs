using Microsoft.AspNetCore.Mvc;

namespace PocketBook.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
