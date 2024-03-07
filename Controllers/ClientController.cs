using Microsoft.AspNetCore.Mvc;

namespace Travail1.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
