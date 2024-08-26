using Microsoft.AspNetCore.Mvc;

namespace Toyota.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
