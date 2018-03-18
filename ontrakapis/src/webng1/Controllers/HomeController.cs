using Microsoft.AspNetCore.Mvc;

namespace webng1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
